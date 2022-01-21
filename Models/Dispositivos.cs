using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet6_web_api.Models
{
    /// <summary>
    /// Clase Dispositivos... 
    /// ...
    /// </summary>
    public class Dispositivos
    {
        public Dispositivos()
        {
            Datos = new HashSet<Datos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Modelo { get; set; }

        public virtual ICollection<Datos> Datos { get; set; }
    }
}