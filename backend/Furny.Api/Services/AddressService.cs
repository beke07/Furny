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

        public AddressService(IConfiguration configuration) : base(configuration, collectionName)
        { }
    }
}
