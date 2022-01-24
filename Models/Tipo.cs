using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet6_web_api.Models
{
    public class Tipo
    {
        public Tipo()
        {
            Dipositivos = new HashSet<Dispositivo>();
        }

        public int Id { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(1000)")]
        public string Descripcion { get; set; }

        public virtual ICollection<Dispositivo> Dipositivos { get; set; }
    }
}