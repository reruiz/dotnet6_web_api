using dotnet6_web_api.Dtos;
using dotnet6_web_api.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet6_web_api.Automapper
{
    public class AutomapperPerfiles: Profile
    {
        public AutomapperPerfiles()
        {
            CreateMap<Dispositivo, DispositivoDTO>().ReverseMap();
            CreateMap<Dispositivo, DispositivoCrearEditarDTO>().ReverseMap();
            
            CreateMap<Dato, DatoDTO>().ReverseMap();
            CreateMap<Dato, DatoCrearEditarDTO>().ReverseMap();
        }
    }
}