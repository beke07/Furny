namespace Furny.Data
{
    public class AddressCommand
    {
        public string _id { get; set; }

        public long ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
