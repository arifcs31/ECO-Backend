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
    public class SessionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly MediaConfiguration _mediaConfiguration;
        private readonly ILogger<SessionController> _logger;

        public SessionController(ILogger<SessionController> logger, IMediator mediator, MediaConfiguration mediaConfiguration)
        {
            _logger = logger;
            _mediator = mediator;
            _mediaConfiguration = mediaConfiguration;
        }

      
        [HttpPost]
        public async Task<long> Add([FromBody] Sessions session)
        {
            return await _mediator.Send(new CreateSessionCommand(session));
        }
        
    }
}
