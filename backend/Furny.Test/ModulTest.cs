using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;
using Furny.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Furny.Test
{
    public class ModulTest : MongoDbTest
    {
        private readonly IModulService _modulService;
        private readonly IDesignerService _designerService;
        private readonly IFurnitureService _furnitureService;

        public ModulTest()
        {
            _modulService = new ModulService(_mapper, _configuration);
            _designerService = new DesignerService(_mapper, new PanelCutterService(_mapper, _configuration), _configuration);
            _furnitureService = new FurnitureService(_mapper, _configuration, new ExportService(new ExcelService()));
        }

        [Fact]
        public async Task AddComponentTest()
        {
            var designer = (await _designerService.Get()).First();
            var designerId = designer.Id.ToString();

            designer.Moduls = new SingleElement<Modul>();
            await _designerService.UpdateAsync(designer);

            await _modulService.CreateAsync(new ModulDto()
            {
                Name = "Modul"
            }, designerId);

            designer = (await _designerService.Get()).First();
            var modulId = designer.Moduls.ElementAt(0).Id.ToString();

            await _modulService.AddComponentAsync(new ComponentDto()
            {
                Name = "Component",
                Height = 3000,
                Width = 1200,
                Closings = new ClosingsDto()
                {
                    Bottom = new ComponentClosingDto()
                    {
                        IsClosed = true
                    },
                    Top = new ComponentClosingDto()
                    {
                        IsClosed = true
                    },
                    Left = new ComponentClosingDto()
                    {
                        IsClosed = true
                    },
                    Right = new ComponentClosingDto()
                    {
                        IsClosed = true
                    }
                }
            }, designerId, modulId);

            designer = (await _designerService.Get()).First();
            var modul = designer.Moduls.ElementAt(0);

            Assert.NotNull(modul);
            Assert.True(modul.Components.Count == 1);
            Assert.True(modul.Name == "Modul");
            Assert.True(modul.Components.ElementAt(0).Name == "Component");
            Assert.True(modul.Components.ElementAt(0).Height == 3000);
            Assert.True(modul.Components.ElementAt(0).Width == 1200);
        }

        [Fact]
        public async Task CopyComponentTest()
        {
            await AddComponentTest();

            var designer = (await _designerService.Get()).First();
            var modul = designer.Moduls.ElementAt(0);
            var component = designer.Moduls.ElementAt(0).Components.ElementAt(0);

            await _modulService.CopyComponentAsync(designer.Id.ToString(), modul.Id.ToString(), component.Id.ToString());

            designer = (await _designerService.Get()).First();
            var components = designer.Moduls.ElementAt(0).Components;

            Assert.True(components.Count == 2);
            Assert.True(components.ElementAt(0).Name == components.ElementAt(1).Name);
            Assert.True(components.ElementAt(0).Height == components.ElementAt(1).Height);
            Assert.True(components.ElementAt(0).Width == components.ElementAt(1).Width);
        }

        [Fact]
        public async Task RemoveComponentTest()
        {
            await AddComponentTest();

            var designer = (await _designerService.Get()).First();
            var modul = designer.Moduls.ElementAt(0);
            var component = designer.Moduls.ElementAt(0).Components.ElementAt(0);

            await _modulService.RemoveComponentAsync(designer.Id.ToString(), modul.Id.ToString(), component.Id.ToString());

            designer = (await _designerService.Get()).First();
            var components = designer.Moduls.ElementAt(0).Components;

            Assert.True(components.Count == 0);
        }
    }
}
