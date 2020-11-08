using AutoMapper;
using Furny.AdFeature.Data;
using Furny.AdFeature.ViewModels;
using Furny.Model;

namespace Furny.AdFeature.MappingProfiles
{
    public class AdMappingProfile : Profile
    {
        public AdMappingProfile()
        {
            CreateMap<AdFeatureAdDto, Ad>().ReverseMap();
            CreateMap<AdFeatureAdTableViewModel, Ad>().ReverseMap();
        }
    }
}
