﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Data
{
    public class ComponentDto
    {
        public string Name { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public ClosingsDto Closings { get; set; }
    }

    public class ClosingsDto
    {
        public ComponentClosingDto Top { get; set; }

        public ComponentClosingDto Bottom { get; set; }

        public ComponentClosingDto Left { get; set; }

        public ComponentClosingDto Right { get; set; }
    }

    public class ComponentClosingDto
    {
        public ClosingDto Closing { get; set; }

        public bool IsClosed { get; set; }
    }
}