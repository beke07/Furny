namespace Furny.ModulFeature.Data
{
    public class ModulComponentDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public ModulClosingsDto Closings { get; set; }
    }

    public class ModulClosingsDto
    {
        public bool Top { get; set; }

        public bool Bottom { get; set; }

        public bool Left { get; set; }

        public bool Right { get; set; }
    }
}
