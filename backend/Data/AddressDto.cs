using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Data
{
    public class AddressDto
    {
        public string Id { get; set; }

        public long ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
