using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet6_web_api.Models;
using dotnet6_web_api.Contexts;

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
        #endregion

        #region Constructor del controlador
        /// <summary>
        /// Contructor del Controlador.
        /// En el constructor se obtienen los diferentes objetos que fueron inicializados en la clase Startup, 
        /// y se transfieren al Controlador mediante la técnica de Inyección de Dependencias.
        /// </summary>
        /// <param name="context">Inyección de objeto BdContext para gestion de BD</param>
        public DispositivosController(ApplicationDbContext context)
        {
            //Asignación de objeto context
            _context = context;
        }
        #endregion

        #region Acciones del controlador

        /// <summary>
        /// Devuelve todos los objetos Dispositivos del usuario actual.
        /// </summary>
        /// <returns>Lista de Dispositivos del usuario actual</returns>
        [HttpGet]
        public ActionResult<List<Dispositivo>> Get()
        {
            //Cuando se ejecuta muy seguido ocurren problemas 
            //(especificamente cuando se implementa el objeto sesión, en la asignación del rol)
            try
            {
                return NotFound();
            }
            catch (System.Exception)
            {
                //En caso de cualquier problema durante el proceso, maneja la excepción
                return NotFound();
            }

        }

        #endregion

    }
}
