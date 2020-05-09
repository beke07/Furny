using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Data
{
    public class UserAddressDto
    {
        public AddressDto Address { get; set; }

        public string StreetAndHouse { get; set; }
    }
}
