using Furny.OrderFeature.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace Furny.OrderFeature.Commands
{
    public class OrderFeatureGetPanelCutterOrdersCommand : IRequest<IList<OrderFeaturePanelCutterTableViewModel>>
    {
        public OrderFeatureGetPanelCutterOrdersCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }

        public static OrderFeatureGetPanelCutterOrdersCommand Create(string id)
            => new OrderFeatureGetPanelCutterOrdersCommand(id);
    }
}
