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

        public override string ToString()
        {
            return Address.ToString() + $"{StreetAndHouse}";
        }
    }
}