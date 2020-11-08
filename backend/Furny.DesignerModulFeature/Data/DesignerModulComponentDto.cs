namespace Furny.DesignerModulFeature.Data
{
    public class DesignerModulComponentDto
    {
        public string Name { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public DesignerModulClosingsDto Closings { get; set; }
    }

    public class DesignerModulClosingsDto
    {
        public DesignerModulComponentClosingDto Top { get; set; }

        public DesignerModulComponentClosingDto Bottom { get; set; }

        public DesignerModulComponentClosingDto Left { get; set; }

        public DesignerModulComponentClosingDto Right { get; set; }
    }

    public class DesignerModulComponentClosingDto
    {
        public bool IsClosed { get; set; }
    }
}
