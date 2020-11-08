using AutoMapper;
using Furny.Common.Models;
using Furny.FurnitureFeature.Data;
using Furny.Model;
using Furny.Model.Common.Commands;
using MediatR;
using MongoDB.Bson;
using System.Linq;

namespace Furny.FurnitureFeature.MappingProfiles.Resolvers
{
    public class FurnitureModulResolver : IValueResolver<FurnitureFurnitureDto, Furniture, SingleElement<Modul>>
    {
        private readonly IMediator _mediator;

        public FurnitureModulResolver(IMediator mediator)
        {
            _mediator = mediator;
        }

        public SingleElement<Modul> Resolve(FurnitureFurnitureDto source, Furniture destination, SingleElement<Modul> destMember, ResolutionContext context)
        {
            var result = new SingleElement<Modul>();

            if (string.IsNullOrEmpty(source.DesignerId))
            {
                return result;
            }

            var designer = _mediator.Send(GetDesignerCommand.Create(source.DesignerId)).Result;

            if (source.Moduls != null && source.Moduls.Count > 0)
            {
                source.Moduls.ToList().ForEach(mid =>
                {
                    result.Add(designer.Moduls.FirstOrDefault(e => e.Id == ObjectId.Parse(mid)));
                });
            }

            return result;
        }
    }
}
