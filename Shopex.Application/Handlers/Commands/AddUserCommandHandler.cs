using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Application.Extensions;
using Shopex.Domain.Configurations;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record AddUserCommand(Users user) : IRequest<LoginResponse> { };

    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, LoginResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly MediaConfiguration _mediaConfiguration;
        public AddUserCommandHandler(IUserRepository userRepository, MediaConfiguration mediaConfiguration)
        {
            _userRepository = userRepository;
            _mediaConfiguration = mediaConfiguration;
        }
        public async Task<LoginResponse> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.Add(request.user);
            if(!result)
            {
                throw new InvalidOperationException("Email Already In Use");
            }
            return await _userRepository.Login(request.user);
        }
        
    }

}
