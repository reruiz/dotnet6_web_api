using AutoMapper;
using dotnet6_web_api.Automapper;
using dotnet6_web_api.Contexts;
using dotnet6_web_api.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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