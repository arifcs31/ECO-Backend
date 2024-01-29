using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopex.Application.Handlers.Queries;
using Shopex.Domain.Model;

namespace Shopex.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UsersController> _logger;

        public AccountController(ILogger<UsersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Users user)
        {
            var result = await _mediator.Send(new LoginCommand(user));
            if(string.IsNullOrEmpty(result.Token))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
