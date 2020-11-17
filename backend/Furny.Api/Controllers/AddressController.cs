using Furny.AddressFeature.Commands;
using Furny.AddressFeature.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : MediatorControllerBase
    {
        public AddressController(IMediator mediator) : base(mediator)
        { }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IList<AddressFeatureAddressViewModel>> Get()
            => await SendAsync(AddressFeatureGetAddressesCommand.Create());
    }
}