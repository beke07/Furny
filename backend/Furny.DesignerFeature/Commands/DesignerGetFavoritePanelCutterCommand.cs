using Furny.Common.Commands;
using Furny.DesignerFeature.ViewModels;
using System.Collections.Generic;

namespace Furny.DesignerFeature.Commands
{
    public class DesignerGetFavoritePanelCutterCommand : GetCommand<IList<DesignerFavoriteViewModel>>
    {
        public DesignerGetFavoritePanelCutterCommand(string id) : base(id)
        { }

        public static DesignerGetFavoritePanelCutterCommand Create(string id)
            => new DesignerGetFavoritePanelCutterCommand(id);
    }
}
