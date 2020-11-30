using AutoMapper;
using Furny.Common.Services;
using Furny.DesignerFeature.Data;
using Furny.DesignerFeature.ServiceInterfaces;
using Furny.DesignerFeature.ViewModels;
using Furny.Model;
using Furny.Model.Common.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public DesignerService(
            IMapper mapper,
            IMediator mediator,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration) : base(configuration, collectionName)
        {
            _mapper = mapper;
            _mediator = mediator;
            _userManager = userManager;
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

            var result = new DesignerHomeViewModel();

            if (designer?.UserAddress?.Address?.Country != null)
                result.Ads = await _mediator.Send(GetPanelCutterAdsCommand.Create(designer.UserAddress.Address.Country));

            return result;
        }

        public async Task<DesignerProfileViewModel> GetProfileAsync(string id)
        {
            var designer = await FindByIdAsync(id);
            return _mapper.Map<DesignerProfileViewModel>(designer);
        }

        public async Task UpdateProfileAsync(JsonPatchDocument<DesignerProfileDto> jsonPatch, string id)
        {
            var designer = await FindByIdAsync(id);
            var profile = _mapper.Map<DesignerProfileDto>(designer);

            jsonPatch.ApplyTo(profile);
            _mapper.Map(profile, designer);

            await UpdateAsync(designer);
        }

        public override async Task<IList<Designer>> Get()
        {
            return await _collection.OfType<Designer>().Find(e => !e.IsDeleted).ToListAsync();
        }

        public async Task<string> GetIdByEmailAsync(string email)
            => await _userManager.GetIdByEmailAsync(email);

        public async Task<IList<DesignerFavoriteViewModel>> GetFavoritesAsnyc(string id)
        {
            var designer = await FindByIdAsync(id);
            return _mapper.Map<IList<DesignerFavoriteViewModel>>(designer.Favorites);
        }
    }
}
