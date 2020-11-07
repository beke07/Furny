using AutoMapper;
using Furny.Common.ViewModels;
using System;

namespace Furny.Model.MappingProfiles.Common.Resolvers
{
    public class AdResolver : IValueResolver<Ad, AdViewModel, string>
    {
        public string Resolve(Ad source, AdViewModel destination, string destMember, ResolutionContext context)
        {
            var ago = DateTime.Now.Subtract(source.Id.CreationTime);

            return ago.Hours < 1 ?
                $"{ago.Minutes} perce" :
                $"{ago.Hours} órája";
        }
    }
}
