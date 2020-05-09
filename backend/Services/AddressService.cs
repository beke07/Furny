using AutoMapper;
using Furny.Data;
using Furny.Filters;
using Furny.Models;
using Furny.ServiceInterfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Net;
using System.Threading.Tasks;

namespace Furny.Services
{
    public class AddressService : BaseService<Address>, IAddressService
    {
        private static string collectionName = "addresses";
        private readonly IMapper _mapper;

        public AddressService(
            IMapper mapper,
            IConfiguration configuration) : base(configuration, collectionName)
        {
            _mapper = mapper;
        }

        public async Task<AddressDto> FindAddressByZipCode(long zipCode)
        {
            var address = await _collection.Find(e => e.ZipCode == zipCode).FirstOrDefaultAsync();

            if(address == null)
            {
                throw new HttpResponseException("Cím nem található!", HttpStatusCode.BadRequest);
            }

            return _mapper.Map<AddressDto>(address);
        }

    }
}
