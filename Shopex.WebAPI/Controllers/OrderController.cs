using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shopex.Application.Handlers.Queries;
using Shopex.Domain.Configurations;
using Shopex.Domain.Dto;
using Shopex.Domain.Model;

namespace Shopex.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly MediaConfiguration _mediaConfiguration;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, IMediator mediator, MediaConfiguration mediaConfiguration)
        {
            _logger = logger;
            _mediator = mediator;
            _mediaConfiguration = mediaConfiguration;
        }
        [HttpGet]
        public async Task<OrderResponseDto> Get([FromQuery] DataFilterDto query)
        {
            return await _mediator.Send(new GetOrdersQuery(query));
        }
        [HttpGet]
        [Route("GetMine")]
        public async Task<OrderResponseDto> GetMine([FromQuery] DataFilterDto query)
        {
            return await _mediator.Send(new GetMineOrdersQuery(query));
        }
        [HttpGet]
        [Route("{orderId}")]
        public async Task<Orders> Get(int orderId)
        {
            return await _mediator.Send(new GetOrderQuery(orderId));
        }
        [HttpPost]
        public async Task<long> Add([FromBody] Orders order)
        {
            _logger.LogInformation("Order Request" + JsonConvert.SerializeObject(order));
            var response = await _mediator.Send(new AddOrderCommand(order));
            _logger.LogInformation("Order Response" + JsonConvert.SerializeObject(order));
            return response;
        }
        [HttpPut]
        public async Task<bool> Update([FromBody] UpdateOrderCommand order)
        {
            return await _mediator.Send(order);
        }

    }
}
