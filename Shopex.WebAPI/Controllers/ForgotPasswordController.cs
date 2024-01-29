using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopex.Application.Handlers.Queries;
using Shopex.Domain.Model;

namespace Shopex.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgotPasswordController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UsersController> _logger;

        public ForgotPasswordController(ILogger<UsersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword([FromBody] Users user)
        {
            var result = await _mediator.Send(new ForgotPasswordCommand(user));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> ResetPassword([FromBody] Users user)
        {
            var result = await _mediator.Send(new ResetPasswordCommand( Convert.ToInt32(user.user_id),user.password));
            return Ok(result);
        }
    }
}
