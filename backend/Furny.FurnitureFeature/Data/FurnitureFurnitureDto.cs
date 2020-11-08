using System.Collections.Generic;

namespace Furny.FurnitureFeature.Data
{
    public class FurnitureFurnitureDto
    {
        public string _id { get; set; }

        public string Name { get; set; }

        public string DesignerId { get; set; }

        public IList<string> Moduls { get; set; }

        public IList<FurnitureComponentDto> Components { get; set; }
    }
}
