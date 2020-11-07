using Furny.Common.Commands;
using Furny.DesignerFeature.ViewModels;

namespace Furny.DesignerFeature.Commands
{
    public class DesignerGetCommand : GetCommand<DesignerHomeViewModel>
    {
        public DesignerGetCommand(string id) : base(id)
        { }

        public static DesignerGetCommand Create(string id)
            => new DesignerGetCommand(id);
    }
}
