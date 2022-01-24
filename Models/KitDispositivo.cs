using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet6_web_api.Models
{
    //Clase utilitaria para unir dispositivos en diferentes Kit,
    //Un dispositivo puede estar en uno o varios Kits
    //No contienes objetos solamente claves foráneas para la navegación
    public class KitDispositivo
    {
        public int Id { get; set; }

        public int DispositivoId { get; set; }

        public int KitId { get; set; }

        public virtual Dispositivo Dispositivo { get; set; }

        public virtual Kit Kit { get; set; }
    }
}