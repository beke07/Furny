using AutoMapper;
using Furny.Data.Designer;
using Furny.Models;
using System;

namespace Furny.MappingProfiles.Resolvers
{
    public class DesignerAdResolver : IValueResolver<Ad, DesignerAdDto, string>
    {
        public string Resolve(Ad source, DesignerAdDto destination, string destMember, ResolutionContext context)
        {
            var ago = DateTime.Now.Subtract(source.Id.CreationTime);

            return ago.Hours < 1 ?
                $"{ago.Minutes} perce" :
                $"{ago.Hours} órája";
        }
    }
}
