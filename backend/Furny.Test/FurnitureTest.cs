using Furny.Common.Enums;
using Furny.Common.Models;
using Furny.DesignerFeature.ServiceInterfaces;
using Furny.FurnitureFeature.Data;
using Furny.FurnitureFeature.ServiceInterfaces;
using Furny.Model;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Furny.Test
{
    public class FurnitureTest : TestBase
    {
        private readonly IFurnitureService _furnitureService;
        private readonly IDesignerService _designerService;

        public FurnitureTest()
        {
            _furnitureService = serviceProvider.GetService<IFurnitureService>();
            _designerService = serviceProvider.GetService<IDesignerService>();
        }

        [Fact]
        public async Task AddFurnitureTest()
        {
            var designer = (await _designerService.Get()).First();

            designer.Furnitures = new SingleElement<Furniture>();
            await _designerService.UpdateAsync(designer);

            await _furnitureService.CreateAsync(new FurnitureFurnitureDto()
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

            await _furnitureService.AddComponentAsync(new FurnitureComponentDto()
            {
                Name = "Component",
                Height = 3000,
                Width = 1200,
                Closings = new FurnitureClosingsDto()
                {
                    Bottom = new FurnitureComponentClosingDto()
                    {
                        IsClosed = true
                    },
                    Top = new FurnitureComponentClosingDto()
                    {
                        IsClosed = true
                    },
                    Left = new FurnitureComponentClosingDto()
                    {
                        IsClosed = true
                    },
                    Right = new FurnitureComponentClosingDto()
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
