using Furny.OrderFeature.Commands;
using Furny.OrderFeature.ServiceInterfaces;
using Furny.OrderFeature.ViewModels;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.OrderFeature.CommandHandlers
{
    public class OrderFeatureGetDesignerOrdersCommandHandler :
        IRequestHandler<OrderFeatureGetDesignerOrdersCommand, IList<OrderFeatureDesignerTableViewModel>>
    {
        private readonly IOrderService _orderService;

        public OrderFeatureGetDesignerOrdersCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IList<OrderFeatureDesignerTableViewModel>> Handle(OrderFeatureGetDesignerOrdersCommand request, CancellationToken cancellationToken)
            => await _orderService.GetDesignerOrdersAsnyc(request.Id);
    }
}
