using AutoMapper;
using Furny.Data;
using Furny.Models;

namespace Furny.MappingProfiles
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            CreateMap<FirebaseUserDto, ApplicationUser>().ReverseMap();

            CreateMap<RegisterDto, ApplicationUser>().ReverseMap();
        }
    }
}
