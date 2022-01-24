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
        /// POST: Crea un nuevo Dispositivo.
        /// </summary>
        /// <param name="datoCreacionDTO">Datos requeridos para crear el nuevo Dispositivo</param>
        /// <returns></returns>
        //Etiqueta que determina el tipo de Acción.(Debe estar presente, sino, genera errores.)
        [HttpPost]
        public async Task<ActionResult> Create(DatoCrearEditarDTO datoCreacionDTO)
        {
            //Traspasa la información recibida desde un DTO a un nuevo objeto MANEJO
            var dato = AutomapperDato.Crear(datoCreacionDTO, _mapper);

            //Almacena la Entidad en la BD
            _context.Add(dato);

            await _context.SaveChangesAsync();

            //Recupera el objeto Dispositivo
            dato = await _context.Datos.FirstOrDefaultAsync(m => m.Id == dato.Id);

            //Mapea nuevamente la Entidad para su despliegue.
            var datoDto = AutomapperDato.DTO(dato, _mapper);

            //Despliegue al usuario del objeto creado en la BD.
            return NoContent();
        }
    }
}