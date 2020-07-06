using Furny.Data;
using Furny.Filters;
using Furny.Models;
using Furny.ServiceInterfaces;
using Furny.Services;
using Microsoft.AspNetCore.JsonPatch;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Furny.Test
{
    public class SingleElementBaseTest : MongoDbTest
    {
        private readonly IAdService _adService;
        private readonly IPanelCutterService _panelCutterService;

        public SingleElementBaseTest()
        {
            _adService = new AdService(_mapper, _configuration);
            _panelCutterService = new PanelCutterService(_mapper, _configuration);
        }

        [Fact]
        public async Task CreateAndGetTest()
        {
            var panelCutter = (await _panelCutterService.Get()).First();
            var panelCutterId = panelCutter.Id.ToString();

            panelCutter.Ads = new SingleElement<Ad>();
            await _panelCutterService.UpdateAsync(panelCutter);

            await _adService.CreateAsync(new AdDto()
            {
                Text = "Text",
                Title = "Title"
            }, panelCutterId);

            var result = (await _adService.GetAsync(panelCutterId)).ElementAt(0);

            Assert.NotNull(result);
            Assert.True(result.Title == "Title");
        }

        [Fact]
        public async Task QuickSearchAsyncTest()
        {
            await CreateAndGetTest();

            var panelCutterId = (await _panelCutterService.Get()).First().Id.ToString();

            var result = await _adService.QuickSearchAsync(panelCutterId, "ti", nameof(Ad.Title));

            Assert.NotNull(result);
            Assert.True(result.Count > 0);
            Assert.True(result.ElementAt(0).Title == "Title");
        }

        [Fact]
        public async Task GetByIdTest()
        {
            await CreateAndGetTest();

            var panelCutterId = (await _panelCutterService.Get()).First().Id.ToString();
            var result = (await _adService.GetAsync(panelCutterId)).ElementAt(0);

            var getByIdResult = await _adService.GetByIdAsync(panelCutterId, result._id);

            Assert.True(getByIdResult.Title == result.Title);
            Assert.True(getByIdResult._id == result._id);
        }

        [Fact]
        public async Task UpdateTest()
        {
            await CreateAndGetTest();

            var panelCutterId = (await _panelCutterService.Get()).First().Id.ToString();
            var ad = (await _adService.GetAsync(panelCutterId)).ElementAt(0);

            var patch = new JsonPatchDocument<AdDto>();

            patch.Replace(e => e.Title, "updatedTitle");
            patch.Replace(e => e.Text, "updatedText");

            await _adService.UpdateAsync(patch, panelCutterId, ad._id);

            var result = await _adService.GetByIdAsync(panelCutterId, ad._id);

            Assert.True(result.Title == "updatedTitle");
            Assert.True(result.Text == "updatedText");
            Assert.True(result._id == ad._id);
        }

        [Fact]
        public async Task RemoveTest()
        {
            await CreateAndGetTest();

            var panelCutterId = (await _panelCutterService.Get()).First().Id.ToString();
            var ad = (await _adService.GetAsync(panelCutterId)).ElementAt(0);

            await _adService.RemoveAsync(panelCutterId, ad._id);

            await Assert.ThrowsAsync<HttpResponseException>(async () => await _adService.GetByIdAsync(panelCutterId, ad._id));
        }
    }
}
