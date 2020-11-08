using System.Collections.Generic;

namespace Furny.DesignerFurnitureFeature.Data
{
    public class DesignerFurnitureFurnitureDto
    {
        public string _id { get; set; }

        public string Name { get; set; }

        public string DesignerId { get; set; }

        public IList<string> Moduls { get; set; }

        public IList<DesignerFurnitureComponentDto> Components { get; set; }
    }
}
