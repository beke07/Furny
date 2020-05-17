using Furny.Common;
using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;
using Furny.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Furny.Common.Enums;

namespace Furny.Test
{
    public class FurnitureTest : MongoDbTest
    {
        private readonly IFurnitureService _furnitureService;
        private readonly IDesignerService _designerService;

        public FurnitureTest()
        {
            _furnitureService = new FurnitureService(_mapper, _configuration, new ExportService(new ExcelService()));
            _designerService = new DesignerService(_mapper, new PanelCutterService(_mapper, _configuration), _configuration);
        }

        [Fact]
        public async Task AddFurnitureTest()
        {
            var designer = (await _designerService.Get()).First();

            designer.Furnitures = new SingleElement<Furniture>();
            await _designerService.UpdateAsync(designer);

            await _furnitureService.CreateAsync(new FurnitureDto()
            {
                Name = "Butor"
            }, designer.Id.ToString());

            designer = (await _designerService.Get()).First();
            var furniture = designer.Furnitures.ElementAt(0);

            Assert.NotNull(furniture);
            Assert.True(furniture.Name == "Butor");
        }

        [Fact]
        public async Task AddModulTest()
        {
            await AddFurnitureTest();

            var modulTest = new ModulTest();
            await modulTest.AddComponentTest();

            var designer = (await _designerService.Get()).First();
            var modul = designer.Moduls.ElementAt(0);
            var furniture = designer.Furnitures.ElementAt(0);

            await _furnitureService.AddModulAsync(designer.Id.ToString(), furniture.Id.ToString(), modul.Id.ToString());

            designer = (await _designerService.Get()).First();
            var moduls = designer.Furnitures.ElementAt(0).Moduls;

            Assert.True(moduls.Count > 0);
            Assert.True(moduls.ElementAt(0).Name == "Modul");
        }

        [Fact]
        public async Task RemoveModulTest()
        {
            await AddModulTest();

            var designer = (await _designerService.Get()).First();
            var modul = designer.Moduls.ElementAt(0);
            var furniture = designer.Furnitures.ElementAt(0);

            await _furnitureService.RemoveModulAsync(designer.Id.ToString(), furniture.Id.ToString(), modul.Id.ToString());

            designer = (await _designerService.Get()).First();
            var moduls = designer.Furnitures.ElementAt(0).Moduls;

            Assert.True(moduls.Count == 0);
        }

        [Fact]
        public async Task AddComponentTest()
        {
            await AddFurnitureTest();

            var designer = (await _designerService.Get()).First();
            var furniture = designer.Furnitures.ElementAt(0);

            furniture.Components = new SingleElement<Component>();
            await _designerService.UpdateAsync(designer);

            await _furnitureService.AddComponentAsync(new ComponentDto()
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
            }, designer.Id.ToString(), furniture.Id.ToString());

            designer = (await _designerService.Get()).First();
            var components = designer.Furnitures.ElementAt(0).Components;

            Assert.True(components.Count > 0);
            Assert.True(components.ElementAt(0).Name == "Component");
            Assert.True(components.ElementAt(0).Height == 3000);
            Assert.True(components.ElementAt(0).Width == 1200);
        }

        [Fact]
        public async Task CopyComponentTest()
        {
            await AddComponentTest();

            var designer = (await _designerService.Get()).First();
            var furniture = designer.Furnitures.ElementAt(0);
            var component = designer.Furnitures.ElementAt(0).Components.ElementAt(0);

            await _furnitureService.CopyComponentAsync(designer.Id.ToString(), furniture.Id.ToString(), component.Id.ToString());

            designer = (await _designerService.Get()).First();
            var components = designer.Furnitures.ElementAt(0).Components;

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
            var furniture = designer.Furnitures.ElementAt(0);
            var component = designer.Furnitures.ElementAt(0).Components.ElementAt(0);

            await _furnitureService.RemoveComponentAsync(designer.Id.ToString(), furniture.Id.ToString(), component.Id.ToString());

            designer = (await _designerService.Get()).First();
            var components = designer.Furnitures.ElementAt(0).Components;

            Assert.True(components.Count == 0);
        }

        [Fact]
        public async Task ExportTest()
        {
            await AddComponentTest();

            var designer = (await _designerService.Get()).First();
            var furniture = designer.Furnitures.ElementAt(0);

            var result = await _furnitureService.ExportAsync(ExcelType.ErFa, designer.Id.ToString(), furniture.Id.ToString());

            Assert.NotNull(result.Item1);
            Assert.NotNull(result.Item2);
            Assert.Contains(ExcelType.ErFa.GetDescription(), result.Item2);
            Assert.True(result.Item1.Length > 0);
        }
    }
}
