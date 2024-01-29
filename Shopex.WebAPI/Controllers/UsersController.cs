using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopex.Application.Handlers.Queries;
using Shopex.Domain.Model;

namespace Shopex.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Users>> Get()
        {
           return await _mediator.Send(new GetUsersQuery()); 
        }
        [HttpGet]
        [Route("{userId}")]
        public async Task<Users> Get(int userId)
        {
            return await _mediator.Send(new GetUserProfileQuery(userId));
        }
        [HttpPost]
        public async Task<LoginResponse> Add([FromBody] Users user)
        {
            return await _mediator.Send(new AddUserCommand(user));
        }
    }
}
