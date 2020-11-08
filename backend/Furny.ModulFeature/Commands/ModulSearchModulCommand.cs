using Furny.Common.Commands;
using Furny.ModulFeature.ViewModels;

namespace Furny.ModulFeature.Commands
{
    public class ModulSearchModulCommand : ISearchSingleElementCommandBase<ModulTableViewModel>
    {
        public ModulSearchModulCommand(string id, string term, string propertyName)
        {
            Id = id;
            Term = term;
            PropertyName = propertyName;
        }

        public string Id { get; set; }

        public string Term { get; set; }

        public string PropertyName { get; set; }

        public static ModulSearchModulCommand Create(string id, string term, string propertyName)
            => new ModulSearchModulCommand(id, term, propertyName);
    }
}
