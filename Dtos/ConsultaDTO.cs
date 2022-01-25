using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet6_web_api.Dtos
{
    public class ConsultaDTO
    {
        public DateTime TiempoInicio { get; set; }

        public DateTime TiempoFin { get; set; }

        public Intervalo Intervalo { get; set; }
        public int DispositivoId { get; set; }
    }

    public enum Intervalo
    {
        horario,

        //Por el momento solo entrega las lecturas directas de la tabla datos
        //diario,
        //mensual,
        //anual
    }
}