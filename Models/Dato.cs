using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet6_web_api.Models
{
    public class Dato
    {
        public int Id { get; set; }
        public DateTime Tiempo { get; set; }
        
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Temperatura { get; set; }
        
        [Column(TypeName = "decimal(5, 2)")]
        public decimal HumedadRelativa { get; set; }
        
        [Column(TypeName = "decimal(5, 2)")]
        public decimal HumedadSuelo { get; set; }
        
        [Column(TypeName = "decimal(6, 2)")]
        public decimal RadiacionSolar { get; set; }
    
        public int DispositivoId { get; set; }

        public virtual Dispositivo Dispositivo { get; set; }
    }
}
