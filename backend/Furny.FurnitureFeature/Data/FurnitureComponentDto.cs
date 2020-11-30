namespace Furny.FurnitureFeature.Data
{
    public class FurnitureComponentDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public FurnitureClosingsDto Closings { get; set; }
    }

    public class FurnitureClosingsDto
    {
        public bool Top { get; set; }

        public bool Bottom { get; set; }

        public bool Left { get; set; }

        public bool Right { get; set; }
    }
}
