namespace Furny.DesignerFurnitureFeature.Data
{
    public class DesignerFurnitureComponentDto
    {
        public string Name { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public DesignerFurnitureClosingsDto Closings { get; set; }
    }

    public class DesignerFurnitureClosingsDto
    {
        public DesignerFurnitureComponentClosingDto Top { get; set; }

        public DesignerFurnitureComponentClosingDto Bottom { get; set; }

        public DesignerFurnitureComponentClosingDto Left { get; set; }

        public DesignerFurnitureComponentClosingDto Right { get; set; }
    }

    public class DesignerFurnitureComponentClosingDto
    {
        public bool IsClosed { get; set; }
    }
}
