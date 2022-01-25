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
    /// Clase Controlador de entidad Dispositivos. Se implementan las funciones básicas
    /// para la capa de persistencia de datos de la Entidad Dispositivos
    /// CRUD: "Crear, Leer, Actualizar y Borrar"
    /// </summary>
    #region Etiquetas del controlador
    //Etiqueta que establece que la clase es un Controlador
    [ApiController]
    [Route("dotnet6_web_api/[controller]")]
    #endregion
    public class DispositivosController : Controller
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
        public DispositivosController(ApplicationDbContext context, IMapper mapper)
        {
            //Asignación de objeto context
            _context = context;
            //Asignación de objeto Mapper
            _mapper = mapper;
        }
        #endregion

        #region Acciones del controlador

        /// <summary>
        /// GET: Devuelve todos los objetos Dispositivos del usuario actual.
        /// </summary>
        /// <returns>Lista de Dispositivos del usuario actual</returns>
        [HttpGet]
        public async Task<ActionResult<List<DispositivoDTO>>> Index()
        {
            //Cuando se ejecuta muy seguido ocurren problemas 
            //(especificamente cuando se implementa el objeto sesión, en la asignación del rol)
            try
            {

                //Crea una lista de la Entidad
                List<Dispositivo> dispositivos = null;

                //Consulta en la base de datos todos los objetos Dispositivos almacenados
                dispositivos = await _context.Dispositivos.ToListAsync();

                //Deberia al menos entregar una lista de Dispositivos vacios, nunca null.
                //En caso de que la repuesta sea null devuelve un error y sale de la acción.
                if (dispositivos == null)
                {
                    return NotFound();
                }

                //Crea una lista de DTO para el despliegue al usuario.
                var dispositivosDto = new List<DispositivoDTO>();

                //Rellena la lista de DTO
                //Formatea: 'programa | id',  ejem 'Trigo | 1'
                foreach (var item in dispositivos)
                {
                    var dispDto = AutomapperDispositivo.DTO(item, _mapper);
                    dispositivosDto.Add(dispDto);
                }

                //Devuelve una lista de DTO.
                return dispositivosDto;
            }
            catch (System.Exception)
            {
                //En caso de cualquier problema durante el proceso, maneja la excepción
                return NotFound();
            }

        }

        /// <summary>
        /// POST: Crea un nuevo Dispositivo.
        /// </summary>
        /// <param name="dispositivoCreacionDTO">Datos requeridos para crear el nuevo Dispositivo</param>
        /// <returns></returns>
        //Etiqueta que determina el tipo de Acción.(Debe estar presente, sino, genera errores.)
        [HttpPost]
        public async Task<ActionResult> Create(DispositivoCrearEditarDTO dispositivoCreacionDTO)
        {
            //Traspasa la información recibida desde un DTO a un nuevo objeto MANEJO
            var dispositivo = AutomapperDispositivo.Crear(dispositivoCreacionDTO, _mapper);

            //Almacena la Entidad en la BD
            _context.Add(dispositivo);

            await _context.SaveChangesAsync();

            //Recupera el objeto Dispositivo
            dispositivo = await _context.Dispositivos.FirstOrDefaultAsync(m => m.Id == dispositivo.Id);

            //Mapea nuevamente la Entidad para su despliegue.
            var dispositivoDto = AutomapperDispositivo.DTO(dispositivo, _mapper);

            //Despliegue al usuario del objeto creado en la BD.
            return new CreatedAtRouteResult("ObtenerDispositivo", new { Id = dispositivoDto.Id }, dispositivoDto);
        }

        /// <summary>
        /// GET: Devuelve los datos del Dispositivo coincidente con el Id buscado.
        /// </summary>
        /// <param name="id"> Id del Dispositivo buscado</param>
        /// <returns></returns>
        //Etiqueta que determina el tipo de Acción.(Debe estar presente, sino, genera errores.)
        [HttpGet("{id}", Name = "ObtenerDispositivo")]
        public async Task<ActionResult<DispositivoDTO>> Details(int id)
        {
            //El Dispositivo existe, y el usuario tiene los permisos para editarlo. Esto se verifico con la clase Permiso
            var dispositivo = await _context.Dispositivos.FirstOrDefaultAsync(m => m.Id == id);

            //Despliegue el objeto buscado en la BD al usuario.
            return AutomapperDispositivo.DTO(dispositivo, _mapper);
        }

        /// <summary>
        /// PUT: Edita un Dispositivo segun su Id.
        /// </summary>
        /// <param name="id">Id del Dispositivo que se editará</param>
        /// <param name="dispositivoEditarDto">Datos del Dispositivo que se editará</param>
        /// <returns></returns>
        //Etiqueta que determina el tipo de Acción.(Debe estar presente, sino, genera errores.)
        [HttpPut("{id:int}")]
        public async Task<ActionResult<DispositivoDTO>> Edit(int id, DispositivoCrearEditarDTO dispositivoEditarDto)
        {
            //El Dispositivo existe, y el usuario tiene los permisos para editarlo. Esto se verifico con la clase Permiso
            var dispositivo = await _context.Dispositivos.FirstOrDefaultAsync(m => (m.Id == id));

            //Se mapea la Entidad con los datos del DTO ingresado por el usuario
            dispositivo = AutomapperDispositivo.Editar(dispositivoEditarDto, dispositivo);

            //Edita la Entidad en la BD
            _context.Entry(dispositivo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            //Se mapea el DTO con los datos de la entidad
            //Se envia al usuario la información editada.
            return AutomapperDispositivo.DTO(dispositivo, _mapper);
        }

        /// <summary>
        /// DELETE: Elimina un Dispositivo según su Id.
        /// </summary>
        /// <param name="id"> Id del Dispositivo a eliminar</param>
        /// <returns></returns>
        //Etiqueta que determina el tipo de Acción.(Debe estar presente, sino, genera errores.)
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            //Consulta por la Entida en la BD, asegurando la correspondencia de PROGRAMA
            var manejo = await _context.Dispositivos.FirstOrDefaultAsync(m => m.Id == id);

            //Elimina la Entidad de la BD
            _context.Remove(manejo);
            await _context.SaveChangesAsync();

            //Se ha eliminado exitosamente la entidad.
            return NoContent();
        }

        #endregion

    }
}
