using Furny.Common.Commands;
using Furny.MaterialFeature.ViewModels;
using System.Collections.Generic;

namespace Furny.MaterialFeature.Commands
{
    public class MaterialFeatureGetMaterialsCommand : GetCommand<IList<MaterialFeatureMaterialTableViewModel>>, IGetSingleElementCommandBase
    {
        public MaterialFeatureGetMaterialsCommand(string id) : base(id)
        { }

        public string ElementId { get; set; }

        public static MaterialFeatureGetMaterialsCommand Create(string id)
            => new MaterialFeatureGetMaterialsCommand(id);
    }
}
