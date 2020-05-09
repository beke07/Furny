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
        }
    }
}
