using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet6_web_api.Dtos
{
    public class DispositivoDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Modelo { get; set; }

        public string Descripcion { get; set; }
    }
}