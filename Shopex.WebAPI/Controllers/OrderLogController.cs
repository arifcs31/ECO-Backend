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
    public class OrderLogController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly MediaConfiguration _mediaConfiguration;
        private readonly ILogger<OrderController> _logger;

        public OrderLogController(ILogger<OrderController> logger, IMediator mediator, MediaConfiguration mediaConfiguration)
        {
            _logger = logger;
            _mediator = mediator;
            _mediaConfiguration = mediaConfiguration;
        }
        
        [HttpPost]
        public async Task<bool> Add([FromBody] OrderLogs orderLogs)
        {
            _logger.LogInformation("Order Request Logs" + JsonConvert.SerializeObject(orderLogs));
            var response = await _mediator.Send(new AddOrderLogCommand(orderLogs));
            _logger.LogInformation("Order Response Logs" + JsonConvert.SerializeObject(orderLogs));
            return response;
        }

    }
}
