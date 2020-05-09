using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Models
{
    public class UserAddress : MongoEntityBase
    {
        public UserAddress() : base()
        { }

        public UserAddress(string id) : base(id)
        { }

        public Address Address { get; set; }

        public string StreetAndHouse { get; set; }
    }
}