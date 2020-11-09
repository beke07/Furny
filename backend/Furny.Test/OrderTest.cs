using Furny.Common.Enums;
using Furny.DesignerFeature.ServiceInterfaces;
using Furny.OrderFeature.Data;
using Furny.OrderFeature.ServiceInterfaces;
using Furny.PanelCutterFeature.ServiceInterfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Furny.Test
{
    public class OrderTest : TestBase
    {
        private readonly IOrderService _orderService;
        private readonly IPanelCutterService _panelCutterService;
        private readonly IDesignerService _designerService;

        public OrderTest()
        {
            _orderService = serviceProvider.GetService<IOrderService>();
            _panelCutterService = serviceProvider.GetService<IPanelCutterService>();
            _designerService = serviceProvider.GetService<IDesignerService>();
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

            var panelCutterOrders = await _orderService.GetPanelCutterOrdersAsnyc(panelCutter.Id.ToString());
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

            var panelCutterOrders = await _orderService.GetPanelCutterOrdersAsnyc(panelCutter.Id.ToString());
            var order = await _orderService.GetById(panelCutterOrders.ElementAt(0)._id);

            await _orderService.AcceptAsnyc(order._id, new OrderFeatureOrderFillDto()
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

            var panelCutterOrders = await _orderService.GetPanelCutterOrdersAsnyc(panelCutter.Id.ToString());
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

            var panelCutterOrders = await _orderService.GetPanelCutterOrdersAsnyc(panelCutter.Id.ToString());
            var order = await _orderService.GetById(panelCutterOrders.ElementAt(0)._id);

            await _orderService.DoneAsnyc(order._id);
            order = await _orderService.GetById(panelCutterOrders.ElementAt(0)._id);

            Assert.True(order.State == OrderState.Done);
        }
    }
}
