namespace Furny.ModulFeature.Data
{
    public class ModulComponentDto
    {
        public string Name { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public ModulClosingsDto Closings { get; set; }
    }

    public class ModulClosingsDto
    {
        public ModulComponentClosingDto Top { get; set; }

        public ModulComponentClosingDto Bottom { get; set; }

        public ModulComponentClosingDto Left { get; set; }

        public ModulComponentClosingDto Right { get; set; }
    }

    public class ModulComponentClosingDto
    {
        public bool IsClosed { get; set; }
    }
}
