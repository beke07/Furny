using AutoMapper;
using Furny.Data;
using Furny.Models;

namespace Furny.MappingProfiles
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            CreateMap<FirebaseUserDto, Designer>().ReverseMap();

            CreateMap<FirebaseUserDto, PanelCutter>().ReverseMap();

            CreateMap<DesignerRegisterDto, Designer>().ReverseMap();

            CreateMap<PanelCutterRegisterDto, PanelCutter>().ReverseMap();
        }
    }
}
