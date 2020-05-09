using AutoMapper;
using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
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

        public async Task CreateMaterialAsync(MaterialDto material, string id)
        {
            var panelCutter = await FindByIdAsync(id);
            panelCutter.AddMaterial(_mapper.Map<Material>(material));

            await UpdateAsync(panelCutter);
        }

        public async Task<MaterialDto> GetMaterialAsync(string id, string mid)
        {
            var panelCutter = await FindByIdAsync(id);
            return _mapper.Map<MaterialDto>(panelCutter.GetMaterial(mid));
        }

        public async Task<IList<MaterialTableDto>> GetMaterialsAsync(string id)
        {
            var panelCutter = await FindByIdAsync(id);
            return _mapper.Map<IList<MaterialTableDto>>(panelCutter.Materials);
        }

        public async Task<PanelCutterProfileDto> GetProfileAsync(string id)
        {
            var panelCutter = await FindByIdAsync(id);
            return _mapper.Map<PanelCutterProfileDto>(panelCutter);
        }

        public async Task RemoveMaterialAsync(string id, string mid)
        {
            var panelCutter = await FindByIdAsync(id);
            panelCutter.RemoveMaterial(mid);

            await UpdateAsync(panelCutter);
        }

        public async Task UpdateMaterialAsync(JsonPatchDocument<MaterialDto> jsonPatch, string id, string mid)
        {
            var panelCutter = await FindByIdAsync(id);
            var material = panelCutter.GetMaterial(mid);

            var materialDto = _mapper.Map<MaterialDto>(material);
            jsonPatch.ApplyTo(materialDto);

            panelCutter.UpdateMaterial(_mapper.Map(materialDto, material), mid);
            await UpdateAsync(panelCutter);
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
