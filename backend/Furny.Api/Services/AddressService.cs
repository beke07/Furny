using Furny.Models;
using Furny.ServiceInterfaces;
using Microsoft.Extensions.Configuration;

namespace Furny.Services
{
    public class AddressService : BaseService<Address>, IAddressService
    {
        private static string collectionName = "addresses";

        public AddressService(IConfiguration configuration) : base(configuration, collectionName)
        { }
    }
}
