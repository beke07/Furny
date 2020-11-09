﻿using Furny.Common.Commands;

namespace Furny.FurnitureFeature.ViewModels
{
    public class FurnitureComponentTableViewModel : TableBaseViewModel
    {
        public string Name { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }
    }
}
