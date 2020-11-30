using AutoMapper;
using Furny.Common.ViewModels;
using Furny.Model.MappingProfiles.Common.Resolvers;
using MongoDB.Bson;
using System;

namespace Furny.Model.Common.MappingProfiles
{
    public class CommonMappingProfile : Profile
    {
        public CommonMappingProfile()
        {
            CreateMap<Ad, AdViewModel>()
                .ForMember(e => e.HourAgo, opt => opt.MapFrom<AdResolver>());

            CreateMap<ObjectId, string>().ConvertUsing<ObjectIdConverter>();
            CreateMap<string, ObjectId>().ConvertUsing<StringConverter>();
        }


        public class ObjectIdConverter : ITypeConverter<ObjectId, string>
        {
            public string Convert(ObjectId source, string destination, ResolutionContext context)
            {
                var result = source.ToString();
                return string.IsNullOrEmpty(result.Trim('0')) ? null : result;
            }
        }

        public class StringConverter : ITypeConverter<string, ObjectId>
        {
            public ObjectId Convert(string source, ObjectId destination, ResolutionContext context)
            {
                if (ObjectId.TryParse(source, out ObjectId dest))
                {
                    return dest;
                }
                else
                {
                    throw new Exception("Nem sikerült a mappelés!");
                }
            }
        }
    }
}
