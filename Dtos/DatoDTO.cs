using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet6_web_api.Dtos
{
    public class DatoDTO
    {
        public int Id { get; set; }
        public DateTime Tiempo { get; set; }
        
        public decimal Temperatura { get; set; }
        
        public decimal HumedadRelativa { get; set; }
        
        public decimal HumedadSuelo { get; set; }
        
        public decimal RadiacionSolar { get; set; }
    
        public string DispositivoId  { get; set; }

    }
}