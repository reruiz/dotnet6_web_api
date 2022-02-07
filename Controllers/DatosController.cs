using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet6_web_api.Models;
using dotnet6_web_api.Contexts;
using Microsoft.EntityFrameworkCore;
using dotnet6_web_api.Dtos;
using dotnet6_web_api.Automapper;
using AutoMapper;


namespace dotnet6_web_api.Controllers
{
    /// <summary>
    /// Controlador de la clase... 
    /// ...
    /// </summary>
    [ApiController]
    [Route("dotnet6_web_api/[controller]")]
    public class DatosController : Controller
    {

        #region Propiedades privadas
        //Objeto inyectado en el constructor para la gestión de la BD mediante Entity
        private readonly ApplicationDbContext _context;

        //Declaracion de objeto Mapper de solo lectura para mapear objetos automaticamente
        private readonly IMapper _mapper;
        #endregion

        #region Constructor del controlador

        /// <summary>
        /// Contructor del Controlador.
        /// En el constructor se obtienen los diferentes objetos que fueron inicializados en la clase Startup, 
        /// y se transfieren al Controlador mediante la técnica de Inyección de Dependencias.
        /// </summary>
        /// <param name="context">Inyección de objeto BdContext para gestion de BD</param>
        /// <param name="mapper">Inyección de objeto Mapper para mapear objetos</param>
        public DatosController(ApplicationDbContext context, IMapper mapper)
        {
            //Asignación de objeto context
            _context = context;
            //Asignación de objeto Mapper
            _mapper = mapper;
        }
        #endregion



        /// <summary>
        /// GET: Devuelve los objetos Datos desde la bd.
        /// </summary>
        /// <param name="consultaDTO">Corresponde a una lista de datos que seran ingresados</param>
        /// <returns></returns>
        //Etiqueta que determina el tipo de Acción.(Debe estar presente, sino, genera errores.)
        [HttpPost("descarga")]
        public async Task<ActionResult<List<DatoDTO>>> Datos(ConsultaDTO consultaDTO)
        {

            //Consulta en la base de datos todos los abjetos Datos almacenados
            var datos = await _context.Datos
                        .Where(e => e.DispositivoId == consultaDTO.DispositivoId)
                        .Where(e => e.Tiempo >= consultaDTO.TiempoInicio)
                        .Where(e => e.Tiempo <= consultaDTO.TiempoFin)
                        .ToListAsync();

            //Crea una lista de DTO para el despliegue al usuario.
            var datosDto = new List<DatoDTO>();

            //Rellena la lista de DTO
            foreach (var item in datos)
            {
                var datDto = AutomapperDato.DTO(item, _mapper);
                datosDto.Add(datDto);
            }

            //Retonar un 200 de operacion exitosa, sin contenido
            return datosDto;
        }

        /// <summary>
        /// POST: Ingresa datos desde dipositivos remotos en la bd.
        /// </summary>
        /// <param name="datosIngresadosDTO">Corresponde a una lista de datos que seran ingresados</param>
        /// <returns></returns>
        //Etiqueta que determina el tipo de Acción.(Debe estar presente, sino, genera errores.)
        [HttpPost]
        public async Task<ActionResult> Create(List<DatoCrearEditarDTO> datosIngresadosDTO)
        {
            //Transforma los Dto y trasfiere la información al repositorio temporal
            //para después grabar los cambios en la bd
            foreach (var datoDto in datosIngresadosDTO)
            {
                //Traspasa la información recibida desde un DTO a un nuevo objeto MANEJO
                var dato = AutomapperDato.Crear(datoDto, _mapper);
                //Almacena la Entidad en la BD
                _context.Add(dato);
            }

            //Almacena los cambios en la base de datos
            await _context.SaveChangesAsync();

            //Retonar un 200 de operacion exitosa, sin contenido
            return NoContent();
        }
    }
}