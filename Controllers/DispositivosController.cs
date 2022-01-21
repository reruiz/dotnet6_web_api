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
    /// Controlador de la clase... 
    /// ...
    /// </summary>
    [ApiController]
    [Route("dotnet6_web_api/[controller]")]
    public class DispositivosController : Controller
    {

    #region Variables inyectadas
private readonly ApplicationDbContext _context;
    #endregion

    #region Constructores
        public DispositivosController(ApplicationDbContext context )
        {
            _context= context;
        }

    #endregion

    #region Acciones del controlador

        /// <summary>
        /// Devuelve información ...
        /// ...
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Dispositivos>> Get()
        {
            var dispositivos = new List<Dispositivos>();
            return Ok(dispositivos);
        }

        /// <summary>
        /// Devuelve información ...
        /// ...
        /// </summary>
        [HttpPost]
        public ActionResult Post(Dispositivos dospositivo)
        {
            return NoContent();
        }

    #endregion

    }
}
