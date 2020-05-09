using AutoMapper;
using Furny.Data;
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
    public class MaterialService : BaseService<PanelCutter>, IMaterialService
    {
        private const string collectionName = "applicationUsers";
        private readonly IMapper _mapper;

        public MaterialService(
            IMapper mapper,
            IConfiguration configuration) : base(configuration, collectionName)
        {
            _mapper = mapper;
        }

        public async Task CreateAsync(MaterialDto material, string id)
        {
            var panelCutter = await FindByIdAsync(id);
            panelCutter.AddMaterial(_mapper.Map<Material>(material));

            await UpdateAsync(panelCutter);
        }

        public async Task<MaterialDto> GetAsync(string id, string mid)
        {
            var panelCutter = await FindByIdAsync(id);
            return _mapper.Map<MaterialDto>(panelCutter.GetMaterial(mid));
        }

        public async Task<IList<MaterialTableDto>> GetAsync(string id)
        {
            var panelCutter = await FindByIdAsync(id);
            return _mapper.Map<IList<MaterialTableDto>>(panelCutter.Materials);
        }


        public async Task RemoveAsync(string id, string mid)
        {
            var panelCutter = await FindByIdAsync(id);
            panelCutter.RemoveMaterial(mid);

            await UpdateAsync(panelCutter);
        }

        public async Task UpdateAsync(JsonPatchDocument<MaterialDto> jsonPatch, string id, string mid)
        {
            var panelCutter = await FindByIdAsync(id);
            var material = panelCutter.GetMaterial(mid);

            var materialDto = _mapper.Map<MaterialDto>(material);
            jsonPatch.ApplyTo(materialDto);

            panelCutter.UpdateMaterial(_mapper.Map(materialDto, material), mid);
            await UpdateAsync(panelCutter);
        }

    }
}
