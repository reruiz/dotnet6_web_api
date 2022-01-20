using Microsoft.AspNetCore.Mvc;
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
        /// <summary>
        /// Devuelve información ...
        /// ...
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}