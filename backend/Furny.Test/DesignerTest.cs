using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;
using Furny.Services;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Furny.Test
{
    public class DesignerTest : MongoDbTest
    {
        private readonly IDesignerService _designerService;
        private readonly IPanelCutterService _panelCutterService;

        public DesignerTest()
        {
            _panelCutterService = new PanelCutterService(_mapper, _configuration);
            _designerService = new DesignerService(_mapper, _panelCutterService, _configuration);
        }

        [Fact]
        public async Task GetProfileTest()
        {
            var designer = (await _designerService.Get()).First();
            var profile = await _designerService.GetProfileAsync(designer.Id.ToString());

            Assert.NotNull(profile);
            Assert.True(profile.ImageId == designer.ImageId);
            Assert.True(profile.Phone == designer.Phone);
            Assert.True(profile.UserName == designer.UserName);
            Assert.True(profile.StreetAndHouse == designer.UserAddress.StreetAndHouse);
            Assert.True(profile.AddressId == designer.UserAddress.Address.Id.ToString());
        }

        [Fact]
        public async Task UpdateProfileTest()
        {
            var designer = (await _designerService.Get()).First();
            var patch = new JsonPatchDocument<DesignerProfileCommand>();

            var addressId = (await _addressService.Get()).First().Id.ToString();

            patch.Replace(e => e.UserName, "updatedUserName");
            patch.Replace(e => e.AddressId, addressId);
            patch.Replace(e => e.StreetAndHouse, "Új út 10.");

            await _designerService.UpdateProfileAsync(patch, designer.Id.ToString());
            var updatedDesigner = (await _designerService.Get()).First();

            Assert.NotNull(updatedDesigner);
            Assert.True(updatedDesigner.UserName == "updatedUserName");
            Assert.True(updatedDesigner.UserAddress.StreetAndHouse == "Új út 10.");
            Assert.True(updatedDesigner.UserAddress.Address.Id.ToString() == addressId);
        }

        [Fact]
        public async Task GetAdsTest()
        {
            var panelCutterTest = new PanelCutterTest();
            await panelCutterTest.AdsByCountryTest();

            var address = (await _addressService.Get()).First();
            var designer = (await _designerService.Get()).First();

            designer.UserAddress = new UserAddress()
            {
                Address = address,
                StreetAndHouse = designer?.UserAddress?.StreetAndHouse
            };

            await _designerService.UpdateAsync(designer);

            var result = await _designerService.GetAdsAsync(designer.Id.ToString());

            var ads = new List<Ad>() {
                new Ad()
                {
                    Text = "Nagyon jók vagyunk!",
                    Title = "Teszt"
                },
                new Ad()
                {
                    Text = "Mégjobbak jók vagyunk!",
                    Title = "Teszt2"
                }
            };

            Assert.True(result.Ads.ElementAt(0).Title == ads.ElementAt(0).Title);
            Assert.True(result.Ads.ElementAt(0).Text == ads.ElementAt(0).Text);
            Assert.True(result.Ads.ElementAt(1).Title == ads.ElementAt(1).Title);
            Assert.True(result.Ads.ElementAt(1).Text == ads.ElementAt(1).Text);
        }

        [Fact]
        public async Task AddFavoritePanelCutterAsyncTest()
        {
            var designer = (await _designerService.Get()).First();
            var panelCutter = (await _panelCutterService.Get()).First();

            designer.Favorites = new SingleElement<PanelCutter>();
            await _designerService.UpdateAsync(designer);

            await _designerService.AddFavoritePanelCutterAsync(designer.Id.ToString(), panelCutter.Id.ToString());

            designer = (await _designerService.Get()).First();

            Assert.True(designer.Favorites.ElementAt(0).Id == panelCutter.Id);
        }

        [Fact]
        public async Task RemoveFavoritePanelCutterAsyncTest()
        {
            await AddFavoritePanelCutterAsyncTest();

            var designer = (await _designerService.Get()).First();
            var panelCutter = (await _panelCutterService.Get()).First();

            await _designerService.RemoveFavoritePanelCutterAsync(designer.Id.ToString(), panelCutter.Id.ToString());

            designer = (await _designerService.Get()).First();

            Assert.NotNull(designer.Favorites);
            Assert.True(designer.Favorites.Count == 0);
        }
    }
}
