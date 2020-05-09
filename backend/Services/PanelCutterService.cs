using AutoMapper;
using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Furny.Services
{
    public class PanelCutterService : BaseService<PanelCutter>, IPanelCutterService
    {
        private const string collectionName = "applicationUsers";
        private readonly IMapper _mapper;

        public PanelCutterService(
            IMapper mapper,
            IConfiguration configuration) : base(configuration, collectionName)
        {
            _mapper = mapper;
        }
        public async Task<PanelCutterProfileDto> GetProfileAsync(string id)
        {
            var panelCutter = await FindByIdAsync(id);
            return _mapper.Map<PanelCutterProfileDto>(panelCutter);
        }

        public async Task UpdateProfileAsync(JsonPatchDocument<PanelCutterProfileDto> jsonPatch, string id)
        {
            var panelCutter = await FindByIdAsync(id);
            var profile = _mapper.Map<PanelCutterProfileDto>(panelCutter);

            jsonPatch.ApplyTo(profile);
            _mapper.Map(profile, panelCutter);

            await UpdateAsync(panelCutter);
        }
    }
}
