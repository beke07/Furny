using AutoMapper;
using Furny.Data;
using Furny.Data.Designer;
using Furny.Models;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IList<DesignerAdCommand>> GetAdsByCountry(string country)
        {
            var panelCutters = await _collection
                .OfType<PanelCutter>()
                .Find(e => e.UserAddress.Address.Country == country)
                .ToListAsync();

            var ads = panelCutters.Select(e => e.Ads);

            IList<DesignerAdCommand> result = new List<DesignerAdCommand>();

            panelCutters.ForEach(panelCutter =>
            {
                panelCutter.Ads.ToList().ForEach(ad =>
                {
                    var adDto = _mapper.Map<DesignerAdCommand>(ad);
                    adDto.PanelCutterId = panelCutter.Id.ToString();
                    adDto.PanelCutterImageId = panelCutter.ImageId;
                    adDto.PanelCutterUserName = panelCutter.UserName;

                    result.Add(adDto);
                });
            });

            return result;
        }

        public async Task<PanelCutterProfileCommand> GetProfileAsync(string id)
        {
            var panelCutter = await FindByIdAsync(id);
            return _mapper.Map<PanelCutterProfileCommand>(panelCutter);
        }

        public async Task UpdateProfileAsync(JsonPatchDocument<PanelCutterProfileCommand> jsonPatch, string id)
        {
            var panelCutter = await FindByIdAsync(id);
            var profile = _mapper.Map<PanelCutterProfileCommand>(panelCutter);

            jsonPatch.ApplyTo(profile);
            _mapper.Map(profile, panelCutter);

            await UpdateAsync(panelCutter);
        }

        public override async Task<IList<PanelCutter>> Get()
        {
            return await _collection.OfType<PanelCutter>().Find(e => !e.IsDeleted).ToListAsync();
        }
    }
}
