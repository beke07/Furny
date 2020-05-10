using AutoMapper;
using Furny.Data;
using Furny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.MappingProfiles
{
    public class DesignerMappingProfiles : Profile
    {
        public DesignerMappingProfiles()
        {
            CreateMap<DesignerProfileDto, Designer>().ReverseMap();
            CreateMap<ComponentDto, Component>().ReverseMap();
            CreateMap<ComponentTableDto, Component>().ReverseMap();
            CreateMap<ComponentClosingDto, ComponentClosing>().ReverseMap();
            CreateMap<ClosingsDto, Closings>().ReverseMap();
            CreateMap<ModulDto, Modul>().ReverseMap();
            CreateMap<ModulTableDto, Modul>().ReverseMap();
        }
    }
}
