using Furny.Common.Commands;
using Furny.ModulFeature.ViewModels;
using System.Collections.Generic;

namespace Furny.ModulFeature.Commands
{
    public class ModulGetModulsCommand : GetCommand<IList<ModulTableViewModel>>, IGetSingleElementCommandBase
    {
        public ModulGetModulsCommand(string id) : base(id)
        { }

        public string ElementId { get; set; }

        public static ModulGetModulsCommand Create(string id)
            => new ModulGetModulsCommand(id);
    }
}
