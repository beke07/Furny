using DocumentFormat.OpenXml.Spreadsheet;
using Furny.ServiceInterfaces;
using Furny.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public async Task GetPanelCutterTest()
        {
            var panelCutters = await _panelCutterService.Get();
            var panelCutter = panelCutters.First();

            Assert.NotNull(panelCutter);
            Assert.True(panelCutter.Name == "Panel Cutter");
        }
    }
}
