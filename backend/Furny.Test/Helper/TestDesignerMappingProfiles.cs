using AutoMapper;
using Furny.Data;
using Furny.Models;
using MongoDB.Driver.Core.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furny.Test.Helper
{
    public class TestDesignerMappingProfiles : Profile
    {
        public TestDesignerMappingProfiles()
        {
            CreateMap<ComponentDto, Component>().ReverseMap();
            CreateMap<ComponentTableDto, Component>().ReverseMap();
            CreateMap<ComponentClosingDto, ComponentClosing>().ReverseMap();
            CreateMap<ClosingsDto, Closings>().ReverseMap();
            CreateMap<ModulDto, Modul>().ReverseMap();
            CreateMap<ModulTableDto, Modul>().ReverseMap();
        }
    }
}
