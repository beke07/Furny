using AutoMapper;
using Furny.Common.Services;
using Furny.DesignerFeature.Commands;
using Furny.DesignerFeature.ServiceInterfaces;
using Furny.DesignerFeature.ViewModels;
using Furny.Model;
using Furny.Model.Common.Commands;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.DesignerFeature.Services
{
    public class DesignerService : BaseService<Designer>, IDesignerService
    {
        private const string collectionName = "applicationUsers";
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DesignerService(
            IMapper mapper,
            IMediator mediator,
            IConfiguration configuration) : base(configuration, collectionName)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task AddFavoritePanelCutterAsync(string id, string pid)
        {
            var designer = await FindByIdAsync(id);
            var panelCutter = await _mediator.Send(GetPanelCutterCommand.Create(pid));

            designer.Favorites.Add(panelCutter);
            await UpdateAsync(designer);
        }

        public async Task RemoveFavoritePanelCutterAsync(string id, string pid)
        {
            var designer = await FindByIdAsync(id);

            designer.Favorites.RemoveById(pid);
            await UpdateAsync(designer);
        }

        public async Task<DesignerHomeViewModel> GetAdsAsync(string id)
        {
            var designer = await FindByIdAsync(id);

            return new DesignerHomeViewModel()
            {
                Ads = await _mediator.Send(GetPanelCutterAdsCommand.Create(designer.UserAddress.Address.Country))
            };
        }

        public async Task<DesignerProfileViewModel> GetProfileAsync(string id)
        {
            var designer = await FindByIdAsync(id);
            return _mapper.Map<DesignerProfileViewModel>(designer);
        }

        public async Task UpdateProfileAsync(JsonPatchDocument<DesignerProfileCommand> jsonPatch, string id)
        {
            var designer = await FindByIdAsync(id);
            var profile = _mapper.Map<DesignerProfileCommand>(designer);

            jsonPatch.ApplyTo(profile);
            _mapper.Map(profile, designer);

            await UpdateAsync(designer);
        }

        public override async Task<IList<Designer>> Get()
        {
            return await _collection.OfType<Designer>().Find(e => !e.IsDeleted).ToListAsync();
        }
    }
}
