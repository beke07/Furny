using AutoMapper;
using Furny.Data;
using Furny.Data.Designer;
using Furny.Models;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Services
{
    public class DesignerService : BaseService<Designer>, IDesignerService
    {
        private const string collectionName = "applicationUsers";
        private readonly IMapper _mapper;
        private readonly IPanelCutterService _panelCutterService;

        public DesignerService(
            IMapper mapper,
            IPanelCutterService panelCutterService,
            IConfiguration configuration) : base(configuration, collectionName)
        {
            _mapper = mapper;
            _panelCutterService = panelCutterService;
        }

        public async Task<DesignerHomeDto> GetAdsAsync(string id)
        {
            var designer = await FindByIdAsync(id);

            return new DesignerHomeDto()
            {
                Ads = await _panelCutterService.GetAdsByCountry(designer.UserAddress.Address.Country)
            };
        }

        public async Task<DesignerProfileDto> GetProfileAsync(string id)
        {
            var designer = await FindByIdAsync(id);
            return _mapper.Map<DesignerProfileDto>(designer);
        }

        public async Task UpdateProfileAsync(JsonPatchDocument<DesignerProfileDto> jsonPatch, string id)
        {
            var designer = await FindByIdAsync(id);
            var profile = _mapper.Map<DesignerProfileDto>(designer);

            jsonPatch.ApplyTo(profile);
            _mapper.Map(profile, designer);

            await UpdateAsync(designer);
        }
    }
}
