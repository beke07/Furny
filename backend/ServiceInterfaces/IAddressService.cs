using Furny.Data;
using Furny.Models;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IAddressService : IBaseService<Address>
    {
        Task<AddressDto> FindAddressByZipCode(long zipCode);
    }
}
