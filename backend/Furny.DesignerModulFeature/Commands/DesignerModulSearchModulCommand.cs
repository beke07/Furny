using Furny.Common.Commands;
using Furny.DesignerModulFeature.ViewModels;

namespace Furny.DesignerModulFeature.Commands
{
    public class DesignerModulSearchModulCommand : ISearchSingleElementCommandBase<DesignerModulModulTableViewModel>
    {
        public DesignerModulSearchModulCommand(string id, string term, string propertyName)
        {
            Id = id;
            Term = term;
            PropertyName = propertyName;
        }

        public string Id { get; set; }

        public string Term { get; set; }

        public string PropertyName { get; set; }

        public static DesignerModulSearchModulCommand Create(string id, string term, string propertyName)
            => new DesignerModulSearchModulCommand(id, term, propertyName);
    }
}
