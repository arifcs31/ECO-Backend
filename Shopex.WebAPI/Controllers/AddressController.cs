using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopex.Application.Handlers.Queries;
using Shopex.Domain.Configurations;
using Shopex.Domain.Dto;
using Shopex.Domain.Model;
using System.Net.Http.Headers;
using Banners = Shopex.Domain.Model.Banners;

namespace Shopex.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly MediaConfiguration _mediaConfiguration;
        private readonly ILogger<AddressController> _logger;

        public AddressController(ILogger<AddressController> logger, IMediator mediator, MediaConfiguration mediaConfiguration)
        {
            _logger = logger;
            _mediator = mediator;
            _mediaConfiguration = mediaConfiguration;
        }

        [HttpGet]
        [Route("{addressId}")]
        public async Task<Address> Get(int addressId)
        {
            return await _mediator.Send(new GetAddressQuery(addressId));
        }
        [HttpGet]
        [Route("[action]/{userId}")]
        public async Task<IEnumerable<Address>> GetBy(int userId)
        {
            return await _mediator.Send(new GetAddressByQuery(userId));
        }
        [HttpPost]
        public async Task<bool> Add([FromBody] Address address)
        {
            return await _mediator.Send(new AddAddressCommand(address));
        }
        [HttpPut]
        public async Task<bool> Update([FromBody] Address address)
        {
            return await _mediator.Send(new UpdateAddressCommand(address));
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<bool> MarkAsBilling([FromBody] int addressId)
        {
            return await _mediator.Send(new MarkAsBillingAddressCommand(addressId));
        }
    }
}
