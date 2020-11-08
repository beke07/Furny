using Furny.Common.Enums;

namespace Furny.MaterialFeature.Data
{
    public class MaterialFeatureMaterialDto
    {
        public string _id { get; set; }

        public string Name { get; set; }

        public long Price { get; set; }

        public MaterialType Type { get; set; }
    }
}
