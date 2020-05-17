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
    public class OfferTest : MongoDbTest
    {
        private readonly IOfferService _offerService;
        private readonly IDesignerService _designerService;
        private readonly IPanelCutterService _panelCutterService;

        public OfferTest()
        {
            _panelCutterService = new PanelCutterService(_mapper, _configuration);
            _designerService = new DesignerService(_mapper, _panelCutterService, _configuration);
            _offerService = new OfferService(_mapper, new FurnitureService(_mapper, _configuration, new ExportService(new ExcelService())),
                _designerService,
                new OrderService(_mapper,
                new FurnitureService(_mapper, _configuration, new ExportService(new ExcelService())),
                new DesignerService(_mapper, new PanelCutterService(_mapper, _configuration), _configuration),
                new NotificationService(_mapper, _configuration),
                _configuration), new NotificationService(_mapper, _configuration), _configuration);
        }

        [Fact]
        public async Task CreateAndGetTask()
        {
            var furnitureTest = new FurnitureTest();
            await furnitureTest.AddComponentTest();

            var panelCutter = (await _panelCutterService.Get()).First();
            panelCutter.Materials = new SingleElement<Material>();
            panelCutter.Closings = new SingleElement<Closing>();
            await _panelCutterService.UpdateAsync(panelCutter);

            var materialService = new MaterialService(_mapper, _configuration);
            await materialService.CreateAsync(new MaterialDto() { Name = "Material", Type = MaterialType.Table, Price = 500 }, panelCutter.Id.ToString());
            await materialService.CreateAsync(new MaterialDto() { Name = "Material 2", Type = MaterialType.M2, Price = 500 }, panelCutter.Id.ToString());

            var closingService = new ClosingService(_mapper, _configuration);
            await closingService.CreateAsync(new ClosingDto() { Name = "Closing" }, panelCutter.Id.ToString());

            panelCutter = (await _panelCutterService.Get()).First();
            var designer = (await _designerService.Get()).First();
            var furniture = designer.Furnitures.ElementAt(0);

            await _database.DropCollectionAsync("offers");

            await _offerService.CreateAsnyc(new OfferDto()
            {
                Components = new List<OfferComponentDto>()
                {
                    new OfferComponentDto()
                    {
                        ComponentId = furniture.Components.ElementAt(0).Id.ToString(),
                        MaterialId = panelCutter.Materials.ElementAt(0).Id.ToString(),
                        ClosingId = panelCutter.Closings.ElementAt(0).Id.ToString(),
                        PanelCutterId = panelCutter.Id.ToString()
                    },
                    new OfferComponentDto()
                    {
                        ComponentId = furniture.Components.ElementAt(0).Id.ToString(),
                        MaterialId = panelCutter.Materials.ElementAt(1).Id.ToString(),
                        ClosingId = panelCutter.Closings.ElementAt(0).Id.ToString(),
                        PanelCutterId = panelCutter.Id.ToString()
                    }
                }
            }, designer.Id.ToString(), furniture.Id.ToString());

            var offers = await _offerService.GetDesignerOffersAsnyc(designer.Id.ToString(), furniture.Id.ToString());

            Assert.NotNull(offers);
            Assert.True(offers.Count > 0);
            Assert.NotNull(offers.ElementAt(0));
            Assert.True(offers.ElementAt(0).State == OfferState.Created);
        }

        [Fact]
        public async Task GetDesignerOffersTest()
        {
            await CreateAndGetTask();

            var designer = (await _designerService.Get()).First();
            var furniture = designer.Furnitures.ElementAt(0);

            var offers = await _offerService.GetDesignerOfferTableAsnyc(designer.Id.ToString(), furniture.Id.ToString());

            Assert.NotNull(offers);
            Assert.True(offers.Count > 0);
            Assert.NotNull(offers.ElementAt(0).FurnitureName = furniture.Name);
            Assert.True(offers.ElementAt(0).State == OfferState.Created);
        }

        [Fact]
        public async Task GetPanelOffersTest()
        {
            await CreateAndGetTask();

            var designer = (await _designerService.Get()).First();
            var panelCutter = (await _panelCutterService.Get()).First();

            var offers = await _offerService.GetPanelCutterOfferTableAsync(panelCutter.Id.ToString());

            Assert.NotNull(offers);
            Assert.True(offers.Count > 0);
            Assert.True(offers.ElementAt(0).DesignerName == designer.Name);
            Assert.True(offers.ElementAt(0).State == OfferState.Created);
        }

        [Fact]
        public async Task GetPanelOfferTest()
        {
            await CreateAndGetTask();

            var panelCutter = (await _panelCutterService.Get()).First();

            var offers = await _offerService.GetPanelCutterOfferTableAsync(panelCutter.Id.ToString());
            var offer = await _offerService.GetPanelCutterOfferAsync(offers.ElementAt(0)._id);

            Assert.NotNull(offer);
            Assert.True(offer.CountedPrice == 2300);
            Assert.True(offer.MaterialQuantity.Keys.ElementAt(0) == "Material");
            Assert.True(offer.MaterialQuantity.Keys.ElementAt(1) == "Material 2");
            Assert.True(offer.MaterialQuantity.Values.ElementAt(0) == "1 tábla");
            Assert.True(offer.MaterialQuantity.Values.ElementAt(1) == "3,6 m²");
        }

        [Fact]
        public async Task FillPanelCutterOfferTest()
        {
            await CreateAndGetTask();

            var panelCutter = (await _panelCutterService.Get()).First();

            var offers = await _offerService.GetPanelCutterOfferTableAsync(panelCutter.Id.ToString());

            await _offerService.FillPanelCutterOfferAsync(new PanelCutterFillOfferDto()
            {
                Price = 10000,
                Deadline = DateTime.Now
            }, offers.ElementAt(0)._id);

            var offer = await _offerService.GetPanelCutterOfferAsync(offers.ElementAt(0)._id);

            Assert.NotNull(offer);
            Assert.True(offer.Offer.Price == 10000);
            Assert.True(offer.Offer.Deadline.Value.Year == DateTime.Now.Year);
            Assert.True(offer.Offer.Deadline.Value.Month == DateTime.Now.Month);
            Assert.True(offer.Offer.Deadline.Value.Day == DateTime.Now.Day);
        }
    }
}
