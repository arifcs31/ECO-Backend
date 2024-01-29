using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopex.Application.Handlers.Queries;
using Shopex.Domain.Configurations;
using Shopex.Domain.Dto;
using Shopex.Domain.Model;
using System.Net.Http.Headers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Banners = Shopex.Domain.Model.Banners;

namespace Shopex.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly MediaConfiguration _mediaConfiguration;
        private readonly ILogger<CartController> _logger;

        public CartController(ILogger<CartController> logger, IMediator mediator, MediaConfiguration mediaConfiguration)
        {
            _logger = logger;
            _mediator = mediator;
            _mediaConfiguration = mediaConfiguration;
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<CartTotalDto> Get(int userId)
        {
            return await _mediator.Send(new GetCartQuery(userId));
        }
        [HttpPost]
        public async Task<bool> Add([FromBody] Carts cart)
        {
            return await _mediator.Send(new AddToCartCommand(cart));
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<bool> Remove([FromBody] Carts cart)
        {
            return await _mediator.Send(new RemoveFromCartCommand(cart));
        }
        [HttpPut]
        public async Task<bool> Update([FromBody] AssignCartCommand cart)
        {
            return await _mediator.Send(cart);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<bool> AssignAddress([FromBody] AssignAddressToCartCommand cart)
        {
            return await _mediator.Send(cart);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<bool> ModifyCart([FromBody] Carts cart)
        {
            return await _mediator.Send(new ModifyCartCommand(cart));
        }

    }
}
