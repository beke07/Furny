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
    public class AdService : BaseService<PanelCutter>, IAdService
    {
        private const string collectionName = "applicationUsers";
        private readonly IMapper _mapper;

        public AdService(
            IMapper mapper,
            IConfiguration configuration) : base(configuration, collectionName)
        {
            _mapper = mapper;
        }

        public async Task<IList<AdDto>> GetAsync(string id)
        {
            var panelCutter = await FindByIdAsync(id);
            return _mapper.Map<IList<AdDto>>(panelCutter.Ads);
        }

        public async Task UpdateAsync(JsonPatchDocument<AdDto> jsonPatch, string id, string adId)
        {
            var panelCutter = await FindByIdAsync(id);
            var ad = panelCutter.GetAd(adId);

            var adDto = _mapper.Map<AdDto>(ad);
            jsonPatch.ApplyTo(adDto);

            panelCutter.UpdateAd(_mapper.Map(adDto, ad), adId);
            await UpdateAsync(panelCutter);
        }

        public async Task RemoveAsync(string id, string adId)
        {
            var panelCutter = await FindByIdAsync(id);
            panelCutter.RemoveAd(adId);

            await UpdateAsync(panelCutter);
        }

        public async Task CreateAsync(AdDto ad, string id)
        {
            var panelCutter = await FindByIdAsync(id);
            panelCutter.AddAd(_mapper.Map<Ad>(ad));

            await UpdateAsync(panelCutter);
        }
    }
}
