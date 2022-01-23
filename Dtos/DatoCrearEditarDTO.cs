using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet6_web_api.Dtos
{
    public class DatoCrearEditarDTO
    {
        public DateTime Tiempo { get; set; }
        
        public decimal Temperatura { get; set; }
        
        public decimal HumedadRelativa { get; set; }
        
        public decimal HumedadSuelo { get; set; }
        
        public decimal RadiacionSolar { get; set; }
    
        public int DispositivoId  { get; set; }

    }
}