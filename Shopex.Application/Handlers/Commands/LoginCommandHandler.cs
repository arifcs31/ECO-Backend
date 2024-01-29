using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Application.Extensions;
using Shopex.Domain.Configurations;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record LoginCommand(Users user) : IRequest<LoginResponse> { };

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IUserRepository _userRepository;
         private readonly MediaConfiguration _mediaConfiguration;
        public LoginCommandHandler(IUserRepository userRepository, MediaConfiguration mediaConfiguration)
        {
            _userRepository = userRepository;
            _mediaConfiguration = mediaConfiguration;
        }
        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.Login(request.user);
        }
        
    }

}
