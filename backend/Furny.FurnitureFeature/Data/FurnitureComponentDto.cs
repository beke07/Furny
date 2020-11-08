namespace Furny.FurnitureFeature.Data
{
    public class FurnitureComponentDto
    {
        public string Name { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public FurnitureClosingsDto Closings { get; set; }
    }

    public class FurnitureClosingsDto
    {
        public FurnitureComponentClosingDto Top { get; set; }

        public FurnitureComponentClosingDto Bottom { get; set; }

        public FurnitureComponentClosingDto Left { get; set; }

        public FurnitureComponentClosingDto Right { get; set; }
    }

    public class FurnitureComponentClosingDto
    {
        public bool IsClosed { get; set; }
    }
}
