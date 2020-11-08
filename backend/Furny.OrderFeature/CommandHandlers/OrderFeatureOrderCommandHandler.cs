using Furny.OrderFeature.Commands;
using Furny.OrderFeature.ServiceInterfaces;
using Furny.OrderFeature.ViewModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.OrderFeature.CommandHandlers
{
    public class OrderFeatureOrderCommandHandler :
        IRequestHandler<OrderFeatureCreateOrderCommand>,
        IRequestHandler<OrderFeatureGetOrderCommand, OrderFeatureOrderViewModel>,
        IRequestHandler<OrderFeatureAcceptOrderCommand>,
        IRequestHandler<OrderFeatureDeclineOrderCommand>,
        IRequestHandler<OrderFeatureDoneOrderCommand>

    {
        private readonly IOrderService _orderService;

        public OrderFeatureOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<Unit> Handle(OrderFeatureCreateOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderService.CreateAsnyc(request.Offer);

            return Unit.Value;
        }

        public async Task<OrderFeatureOrderViewModel> Handle(OrderFeatureGetOrderCommand request, CancellationToken cancellationToken)
            => await _orderService.GetById(request.Id);

        public async Task<Unit> Handle(OrderFeatureDoneOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderService.DoneAsnyc(request.Id);

            return Unit.Value;
        }

        public async Task<Unit> Handle(OrderFeatureDeclineOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderService.DeclineAsnyc(request.Id);

            return Unit.Value;
        }

        public async Task<Unit> Handle(OrderFeatureAcceptOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderService.AcceptAsnyc(request.Id, request.Fill);

            return Unit.Value;
        }
    }
}
