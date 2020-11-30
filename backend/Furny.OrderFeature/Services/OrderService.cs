using AutoMapper;
using Furny.Common.Enums;
using Furny.Common.Services;
using Furny.FurnitureFeature.Commands;
using Furny.Model;
using Furny.Model.Common.Commands;
using Furny.NotificationFeature.Commands;
using Furny.OrderFeature.ServiceInterfaces;
using Furny.OrderFeature.ViewModels;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.OrderFeature.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        private const string collectionName = "orders";
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public OrderService(
            IMapper mapper,
            IMediator mediator,
            IConfiguration configuration) : base(configuration, collectionName)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<OrderFeatureOrderViewModel> GetById(string id)
        {
            var order = await FindByIdAsync(id);
            return _mapper.Map<OrderFeatureOrderViewModel>(order);
        }

        public async Task<IList<OrderFeaturePanelCutterTableViewModel>> GetPanelCutterOrdersAsnyc(string panelCutterId)
        {
            var orders = (await Get()).Where(e => e.Offer.PanelCutterId == panelCutterId);

            return orders.Select(e => new OrderFeaturePanelCutterTableViewModel()
            {
                DesignerName = _mediator.Send(GetDesignerCommand.Create(e.Offer.DesignerId)).Result.Name,
                OfferId = e.Offer.Id.ToString(),
                State = e.State,
                Id = e.Id.ToString(),
                CreatedOn = e.Id.CreationTime
            }).ToList();
        }

        public async Task<IList<OrderFeatureDesignerTableViewModel>> GetDesignerOrdersAsnyc(string designerId)
        {
            var orders = (await Get()).Where(e => e.Offer.DesignerId == designerId);

            return orders.Select(e => new OrderFeatureDesignerTableViewModel()
            {
                Name = _mediator.Send(FurnitureGetFurnitureCommand.Create(designerId, e.Offer.FurnitureId)).Result.Name,
                FurnitureId = e.Offer.FurnitureId,
                OfferId = e.Offer.Id.ToString(),
                State = e.State,
                Id = e.Id.ToString(),
                CreatedOn = e.Id.CreationTime
            }).ToList();
        }

        public async Task DoneAsnyc(string id)
        {
            var order = await FindByIdAsync(id);
            order.State = OrderState.Done;

            await UpdateAsync(order);

            await _mediator.Send(NotificationFeatureCreateNotificationCommand.Create(order.Offer.DesignerId, new Notification()
            {
                Text = order.Delivery ?
                    "A megrendelés elkészült, szállítását megkezdtük!" :
                    "A megrendelés elkészült, címünkön átvehető!",
                Link = "designer-orders"
            }));
        }

        public async Task CreateAsnyc(Offer offer)
        {
            await _collection.InsertOneAsync(new Order() { Offer = offer });
        }
    }
}
