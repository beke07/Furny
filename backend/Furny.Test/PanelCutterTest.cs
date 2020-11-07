using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;
using Furny.Services;
using Microsoft.AspNetCore.JsonPatch;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Furny.Test
{
    public class PanelCutterTest : MongoDbTest
    {
        private readonly IPanelCutterService _panelCutterService;

        public PanelCutterTest()
        {
            _panelCutterService = new PanelCutterService(_mapper, _configuration);
        }

        [Fact]
        public async Task GetProfileTest()
        {
            var panelCutter = (await _panelCutterService.Get()).First();
            var profile = await _panelCutterService.GetProfileAsync(panelCutter.Id.ToString());

            Assert.NotNull(profile);
            Assert.True(profile.Opened == panelCutter.Opened);
            Assert.True(profile.ImageId == panelCutter.ImageId);
            Assert.True(profile.Facebook == panelCutter.Facebook);
            Assert.True(profile.Phone == panelCutter.Phone);
            Assert.True(profile.UserName == panelCutter.UserName);
            Assert.True(profile.StreetAndHouse == panelCutter.UserAddress.StreetAndHouse);
            Assert.True(profile.AddressId == panelCutter.UserAddress.Address.Id.ToString());
        }

        [Fact]
        public async Task UpdateProfileTest()
        {
            var panelCutter = (await _panelCutterService.Get()).First();
            var patch = new JsonPatchDocument<PanelCutterProfileCommand>();

            var addressId = (await _addressService.Get()).First().Id.ToString();

            patch.Replace(e => e.UserName, "updatedUserName");
            patch.Replace(e => e.AddressId, addressId);
            patch.Replace(e => e.StreetAndHouse, "Új út 10.");

            await _panelCutterService.UpdateProfileAsync(patch, panelCutter.Id.ToString());
            var updatedPanelCutter = (await _panelCutterService.Get()).First();

            Assert.NotNull(updatedPanelCutter);
            Assert.True(updatedPanelCutter.UserName == "updatedUserName");
            Assert.True(updatedPanelCutter.UserAddress.StreetAndHouse == "Új út 10.");
            Assert.True(updatedPanelCutter.UserAddress.Address.Id.ToString() == addressId);
        }

        [Fact]
        public async Task AdsByCountryTest()
        {
            await UpdateProfileTest();

            var panelCutter = (await _panelCutterService.Get()).First();
            var address = (await _addressService.Get()).First();

            var ad = new Ad()
            {
                Text = "Nagyon jók vagyunk!",
                Title = "Teszt"
            };

            var ad2 = new Ad()
            {
                Text = "Mégjobbak jók vagyunk!",
                Title = "Teszt2"
            };

            panelCutter.Ads = new SingleElement<Ad>() { ad, ad2 };
            await _panelCutterService.UpdateAsync(panelCutter);

            var ads = await _panelCutterService.GetAdsByCountry(address.Country);

            Assert.NotNull(ads);
            Assert.True(ads.Count == 2);
            Assert.True(ads.ElementAt(0).PanelCutterUserName == panelCutter.UserName);
            Assert.True(ads.ElementAt(0).PanelCutterId == panelCutter.Id.ToString());
            Assert.True(ads.ElementAt(0).Text == ad.Text);
            Assert.True(ads.ElementAt(0).Title == ad.Title);
            Assert.True(ads.ElementAt(1).Text == ad2.Text);
            Assert.True(ads.ElementAt(1).Title == ad2.Title);
        }
    }
}
