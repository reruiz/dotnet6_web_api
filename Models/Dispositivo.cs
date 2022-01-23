using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet6_web_api.Models
{
    public class Dispositivo
    {
        public Dispositivo()
        {
            Datos = new HashSet<Dato>();
        }

        public int Id { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Modelo { get; set; }

        [Column(TypeName = "varchar(1000)")]
        public string Descripcion { get; set; }

        public virtual ICollection<Dato> Datos { get; set; }
    }
}