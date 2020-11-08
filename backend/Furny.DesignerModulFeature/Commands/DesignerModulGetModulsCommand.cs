using Furny.Common.Commands;
using Furny.DesignerModulFeature.ViewModels;
using System.Collections.Generic;

namespace Furny.DesignerModulFeature.Commands
{
    public class DesignerModulGetModulsCommand : GetCommand<IList<DesignerModulModulTableViewModel>>, IGetSingleElementCommandBase
    {
        public DesignerModulGetModulsCommand(string id) : base(id)
        { }

        public string ElementId { get; set; }

        public static DesignerModulGetModulsCommand Create(string id)
            => new DesignerModulGetModulsCommand(id);
    }
}
