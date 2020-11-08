using AutoMapper;
using Furny.ClosingFeature.Data;
using Furny.ClosingFeature.ViewModels;
using Furny.Model;

namespace Furny.ClosingFeature.MappingProfiles
{
    public class ClosingMappingProfile : Profile
    {
        public ClosingMappingProfile()
        {
            CreateMap<ClosingFeatureClosingDto, Closing>().ReverseMap();
            CreateMap<ClosingFeatureClosingTableViewModel, Closing>().ReverseMap();
        }
    }
}
