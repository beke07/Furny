﻿using static Furny.Common.Enums;

namespace Furny.Data
{
    public class MaterialDto
    {
        public string _id { get; set; }

        public string Name { get; set; }

        public long Price { get; set; }

        public MaterialType Type { get; set; }
    }
}
