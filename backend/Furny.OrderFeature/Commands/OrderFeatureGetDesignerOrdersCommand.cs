using Furny.OrderFeature.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace Furny.OrderFeature.Commands
{
    public class OrderFeatureGetDesignerOrdersCommand : IRequest<IList<OrderFeatureDesignerTableViewModel>>
    {
        public OrderFeatureGetDesignerOrdersCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }

        public static OrderFeatureGetDesignerOrdersCommand Create(string id)
            => new OrderFeatureGetDesignerOrdersCommand(id);
    }
}
