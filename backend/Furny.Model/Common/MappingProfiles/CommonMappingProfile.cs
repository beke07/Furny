using AutoMapper;
using Furny.Common.ViewModels;
using Furny.Model.MappingProfiles.Common.Resolvers;

namespace Furny.Model.Common.MappingProfiles
{
    public class CommonMappingProfile : Profile
    {
        public CommonMappingProfile()
        {
            CreateMap<Ad, AdViewModel>()
                .ForMember(e => e.HourAgo, opt => opt.MapFrom<AdResolver>());
        }
    }
}
