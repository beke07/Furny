using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Models
{
    public class Address : MongoEntityBase
    {
        public Address() : base()
        { }

        public Address(string id) : base(id)
        { }

        public long ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
