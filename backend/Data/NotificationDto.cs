using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Data
{
    public class NotificationDto
    {
        public string _id { get; set; }

        public string Link { get; set; }

        public string Text { get; set; }

        public bool IsDone { get; set; }
    }
}
