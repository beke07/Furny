using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Models
{
    public class Ad : MongoEntityBase
    {
        public Ad() : base()
        { }

        public Ad(string id) : base(id)
        { }

        public string Text { get; set; }

        public string ImageId { get; set; }
    }
}
