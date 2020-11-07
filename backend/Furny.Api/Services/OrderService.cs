using AutoMapper;
using Furny.Common.Enums;
using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        private const string collectionName = "orders";
        private readonly IMapper _mapper;
        private readonly IFurnitureService _furnitureService;
        private readonly IDesignerService _designerService;
        private readonly INotificationService _notificationService;

        public OrderService(
            IMapper mapper,
            IFurnitureService furnitureService,
            IDesignerService designerService,
            INotificationService notificationService,
            IConfiguration configuration) : base(configuration, collectionName)
        {
            _mapper = mapper;
            _furnitureService = furnitureService;
            _designerService = designerService;
            _notificationService = notificationService;
        }

        public async Task<OrderCommand> GetById(string id)
        {
            var order = await FindByIdAsync(id);
            return _mapper.Map<OrderCommand>(order);
        }

        public async Task<IList<PanelCutterOrderTableCommand>> GetPanelOrdersAsnyc(string panelCutterId)
        {
            var orders = (await Get()).Where(e => e.Offer.PanelCutterId == panelCutterId);

            return orders.Select(e => new PanelCutterOrderTableCommand()
            {
                DesignerName = _designerService.FindByIdAsync(e.Offer.DesginerId).Result.Name,
                State = e.State,
                _id = e.Id.ToString(),
                CreatedOn = e.Id.CreationTime
            }).ToList();
        }

        public async Task<IList<DesignerOrderTableCommand>> GetDesignerOrdersAsnyc(string designerId)
        {
            var orders = (await Get()).Where(e => e.Offer.DesginerId == designerId);

            return orders.Select(e => new DesignerOrderTableCommand()
            {
                Name = _furnitureService.GetByIdAsync(designerId, e.Offer.FurnitureId).Result.Name,
                State = e.State,
                _id = e.Id.ToString(),
                CreatedOn = e.Id.CreationTime
            }).ToList();
        }

        public async Task CreateAsnyc(Offer offer)
        {
            await _collection.InsertOneAsync(new Order() { Offer = offer });
        }

        public async Task AcceptAsnyc(string id, OrderFillCommand orderDto)
        {
            var order = await FindByIdAsync(id);
            order.Delivery = orderDto.Delivery;
            order.Comment = orderDto.Comment;
            order.State = OrderState.Accepted;

            await UpdateAsync(order);

            await _notificationService.CreateNotificationAsync(order.Offer.PanelCutterId, new Notification()
            {
                Text = "A megrendelő elfogadta az árajánlatot, megrendelés érkezett!"
            });
        }

        public async Task DeclineAsnyc(string id)
        {
            var order = await FindByIdAsync(id);
            order.State = OrderState.Declined;

            await UpdateAsync(order);

            await _notificationService.CreateNotificationAsync(order.Offer.PanelCutterId, new Notification()
            {
                Text = "A megrendelő elutasította az árajánlatot!"
            });
        }

        public async Task DoneAsnyc(string id)
        {
            var order = await FindByIdAsync(id);
            order.State = OrderState.Done;

            await UpdateAsync(order);

            await _notificationService.CreateNotificationAsync(order.Offer.DesginerId, new Notification()
            {
                Text = order.Delivery ?
                    "A megrendelés elkészült, szállítását megkezdtük!" :
                    "A megrendelés elkészült, címünkön átvehető!"
            });
        }
    }
}
