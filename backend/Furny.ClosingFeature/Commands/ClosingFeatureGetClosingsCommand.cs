using Furny.ClosingFeature.ViewModels;
using Furny.Common.Commands;
using System.Collections.Generic;

namespace Furny.ClosingFeature.Commands
{
    public class ClosingFeatureGetClosingsCommand : GetCommand<IList<ClosingFeatureClosingTableViewModel>>, IGetSingleElementCommandBase
    {
        public ClosingFeatureGetClosingsCommand(string id) : base(id)
        { }

        public string ElementId { get; set; }

        public static ClosingFeatureGetClosingsCommand Create(string id)
            => new ClosingFeatureGetClosingsCommand(id);
    }
}
