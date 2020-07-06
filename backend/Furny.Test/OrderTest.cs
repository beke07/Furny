using Furny.Data;
using Furny.ServiceInterfaces;
using Furny.Services;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static Furny.Common.Enums;

namespace Furny.Test
{
    public class OrderTest : MongoDbTest
    {
        private readonly IOrderService _orderService;
        private readonly IPanelCutterService _panelCutterService;
        private readonly IDesignerService _designerService;

        public OrderTest()
        {
            _panelCutterService = new PanelCutterService(_mapper, _configuration);
            _designerService = new DesignerService(_mapper, _panelCutterService, _configuration);
            _orderService = new OrderService(_mapper,
                new FurnitureService(_mapper, _configuration, new ExportService(new ExcelService())),
                new DesignerService(_mapper, _panelCutterService, _configuration),
                new NotificationService(_mapper, _configuration),
                _configuration);
        }

        [Fact]
        public async Task CreateTest()
        {
            var offerTest = new OfferTest();
            await offerTest.CreateAndGetTask();

            await _database.DropCollectionAsync("orders");
            await offerTest.FillPanelCutterOfferTest();

            var panelCutter = (await _panelCutterService.Get()).First();
            var designer = (await _designerService.Get()).First();

            var panelCutterOrders = await _orderService.GetPanelOrdersAsnyc(panelCutter.Id.ToString());
            var designerOrders = await _orderService.GetDesignerOrdersAsnyc(designer.Id.ToString());

            Assert.True(panelCutterOrders.ElementAt(0)._id == designerOrders.ElementAt(0)._id);

            var order = await _orderService.GetById(designerOrders.ElementAt(0)._id);

            Assert.NotNull(order);
            Assert.True(
                order.State == panelCutterOrders.ElementAt(0).State &&
                order.State == designerOrders.ElementAt(0).State);
            Assert.True(panelCutterOrders.ElementAt(0).DesignerName == designer.Name);
            Assert.True(designerOrders.ElementAt(0).Name == designer.Furnitures.ElementAt(0).Name);
        }

        [Fact]
        public async Task AcceptTest()
        {
            await CreateTest();

            var panelCutter = (await _panelCutterService.Get()).First();

            var panelCutterOrders = await _orderService.GetPanelOrdersAsnyc(panelCutter.Id.ToString());
            var order = await _orderService.GetById(panelCutterOrders.ElementAt(0)._id);

            await _orderService.AcceptAsnyc(order._id, new OrderFillDto()
            {
                Comment = "Komment",
                Delivery = true
            });
            order = await _orderService.GetById(panelCutterOrders.ElementAt(0)._id);

            Assert.True(order.State == OrderState.Accepted);
        }

        [Fact]
        public async Task DeclineTest()
        {
            await CreateTest();

            var panelCutter = (await _panelCutterService.Get()).First();

            var panelCutterOrders = await _orderService.GetPanelOrdersAsnyc(panelCutter.Id.ToString());
            var order = await _orderService.GetById(panelCutterOrders.ElementAt(0)._id);

            await _orderService.DeclineAsnyc(order._id);
            order = await _orderService.GetById(panelCutterOrders.ElementAt(0)._id);

            Assert.True(order.State == OrderState.Declined);
        }

        [Fact]
        public async Task DoneTest()
        {
            await CreateTest();

            var panelCutter = (await _panelCutterService.Get()).First();

            var panelCutterOrders = await _orderService.GetPanelOrdersAsnyc(panelCutter.Id.ToString());
            var order = await _orderService.GetById(panelCutterOrders.ElementAt(0)._id);

            await _orderService.DoneAsnyc(order._id);
            order = await _orderService.GetById(panelCutterOrders.ElementAt(0)._id);

            Assert.True(order.State == OrderState.Done);
        }
    }
}
