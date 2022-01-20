using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet6_web_api.Models;

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
        /// <summary>
        /// Devuelve información ...
        /// ...
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Dispositivos>> Get()
        {
            return new List<Dispositivos>() {
                new Dispositivos() { Id = 1, Nombre = "Santa Rosa" },
                new Dispositivos() { Id = 2, Nombre = "Cauquenes" }
            };
        }
    }
}
