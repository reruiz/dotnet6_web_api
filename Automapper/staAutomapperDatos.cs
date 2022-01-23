using dotnet6_web_api.Dtos;
using dotnet6_web_api.Models;
using dotnet6_web_api.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet6_web_api.Automapper
{
    /// <summary>
    /// Una clase personalizada para auto mapear de objetos DTO a objetos Entidades y viceversa.
    /// Una clase 'AutomapperEntidad' por entidad que es necesario mapear en los controladores.
    /// Simplifica codigo y atiende a las particularidades que automapper no soluciona facilmente.
    /// </summary>
    public class AutomapperDatos
    {
        /// <summary>
        /// Mapea DTO para visualizar.
        /// Devuelve un objeto DTO a partir de un objeto Datos
        /// </summary>
        /// <param name="fuente">Objeto Dato</param>
        /// <param name="mapper">Objeto mapper inyectado</param>
        /// <returns>Clase DTO para visualización por el usuario</returns>
        public static DatoDTO DTO(Dato fuente, IMapper mapper)
        {
            //Utiliza Automapper Tradicional
            //No es necesario formatear mediante la clase DtoFormato (carpeta Services)
            var datoDto = mapper.Map<DatoDTO>(fuente);
            //Devuelve nuevo DTO
            return datoDto;
        }

        /// <summary>
        /// Mapea entidad para edición de objeto en BD.
        /// Devuelve un objeto Dato a partir de una clase DTO ingresada por el usuario.
        /// </summary>
        /// <param name="fuente">DTO ingresada por el usuario</param>
        /// <param name="destino">Entidad</param>
        /// <returns>Entidad para editar BD</returns>
        public static Dato Editar(DatoCrearEditarDTO fuente, Dato destino)
        {
            //No se implementará la capadidad de editar datos en la api
            return destino;
        }

        /// <summary>
        /// Mapea entidad para creación de objeto en BD
        /// Devuelve un objeto Dato a partir de una clase DTO ingresada por el usuario.
        /// </summary>
        /// <param name="fuente">DTO ingresada por el usuario</param>
        /// <param name="mapper">Objeto mapper inyectado</param>
        /// <returns>Entidad para crear BD</returns>
        public static Dato Crear(DispositivoCrearEditarDTO fuente, IMapper mapper)
        {
            var dato = mapper.Map<Dato>(fuente);
            return dato;
        }
    }
}