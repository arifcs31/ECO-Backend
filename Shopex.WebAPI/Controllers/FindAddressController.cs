using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopex.Application.Handlers.Queries;
using Shopex.Domain.Configurations;
using Shopex.Domain.Dto;

namespace Shopex.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindAddressController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly MediaConfiguration _mediaConfiguration;
        private readonly ILogger<AddressController> _logger;

        public FindAddressController(ILogger<AddressController> logger, IMediator mediator, MediaConfiguration mediaConfiguration)
        {
            _logger = logger;
            _mediator = mediator;
            _mediaConfiguration = mediaConfiguration;
        }

        [HttpGet]
        [Route("{search}/{postcode}")]
        public async Task<AddressResult> Get(string search,string postcode)
        {
            return await _mediator.Send(new GetFindAddressQuery(search,postcode));
        }
      
    }
}
