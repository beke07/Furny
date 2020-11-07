using Furny.Common.Models;

namespace Furny.Model
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

        public override string ToString()
        {
            return $"{ZipCode} {City} ";
        }
    }
}
