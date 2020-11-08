using Furny.OrderFeature.Commands;
using Furny.OrderFeature.ServiceInterfaces;
using Furny.OrderFeature.ViewModels;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.OrderFeature.CommandHandlers
{
    public class OrderFeaturePanelCutterOrdersCommandHandler :
        IRequestHandler<OrderFeatureGetPanelCutterOrdersCommand, IList<OrderFeaturePanelCutterTableViewModel>>
    {
        private readonly IOrderService _orderService;

        public OrderFeaturePanelCutterOrdersCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IList<OrderFeaturePanelCutterTableViewModel>> Handle(OrderFeatureGetPanelCutterOrdersCommand request, CancellationToken cancellationToken)
            => await _orderService.GetPanelCutterOrdersAsnyc(request.Id);
    }
}
