using Furny.Common.Filters;
using Furny.PanelCutterFeature.ServiceInterfaces;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Furny.Test
{
    public class BaseTest : TestBase
    {
        private readonly IPanelCutterService _panelCutterService;

        public BaseTest()
        {
            _panelCutterService = serviceProvider.GetService<IPanelCutterService>();
        }

        [Fact]
        public async Task GetTest()
        {
            var panelDefaultCutter = (await _panelCutterService.Get()).First();

            panelDefaultCutter.UserName = "panelcutter";
            panelDefaultCutter.Email = "panel-cutter@furny.hu";
            panelDefaultCutter.Name = "Panel Cutter";

            await _panelCutterService.UpdateAsync(panelDefaultCutter);

            var panelCutter = (await _panelCutterService.Get()).First();

            Assert.NotNull(panelCutter);
            Assert.True(panelCutter.UserName == "panelcutter");
            Assert.True(panelCutter.Email == "panel-cutter@furny.hu");
            Assert.True(panelCutter.Name == "Panel Cutter");
        }


        [Fact]
        public async Task FindByIdTest()
        {
            var panelCutter = (await _panelCutterService.Get()).First();
            var panelCutterById = await _panelCutterService.FindByIdAsync(panelCutter.Id.ToString());

            Assert.NotNull(panelCutterById);
            Assert.True(panelCutterById.Name == panelCutter.Name);
            Assert.True(panelCutterById.UserName == panelCutter.UserName);
            Assert.True(panelCutterById.Email == panelCutter.Email);
        }

        [Fact]
        public async Task FindNotByIdTest()
        {
            await Assert.ThrowsAsync<HttpResponseException>(async () => await _panelCutterService.FindByIdAsync(ObjectId.GenerateNewId().ToString()));
        }

        [Fact]
        public async Task UpdateTest()
        {
            var panelCutter = (await _panelCutterService.Get()).First();

            panelCutter.UserName = "updatedPanelCutter";
            panelCutter.Email = "updated@furny.hu";
            panelCutter.Name = "updatedPanelC";

            await _panelCutterService.UpdateAsync(panelCutter);
            var updatedPanelCutter = (await _panelCutterService.Get()).First();

            Assert.NotNull(updatedPanelCutter);
            Assert.True(updatedPanelCutter.Name == panelCutter.Name);
            Assert.True(updatedPanelCutter.UserName == panelCutter.UserName);
            Assert.True(updatedPanelCutter.Email == panelCutter.Email);
        }
    }
}
