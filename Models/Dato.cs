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
    public class Dato
    {
        public int Id { get; set; }
        public DateTime Tiempo { get; set; }
        public decimal Temperatura { get; set; }
        public decimal HumedadRelativa { get; set; }
        public decimal HumedadSuelo { get; set; }
        public decimal RadiacionSolar { get; set; }
        public decimal DispositivoId { get; set; }

        public virtual Dispositivo Dispositivo { get; set; }
    }
}
