﻿using System.Collections.Generic;

namespace Furny.Data
{
    public class PanelCutterProfileDto
    {
        public string UserName { get; set; }

        public string ImageId { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Opened { get; set; }

        public string Facebook { get; set; }

        public IList<string> Extras { get; set; }
    }
}
