using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Application.Extensions;
using Shopex.Domain.Configurations;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record ForgotPasswordCommand(Users user) : IRequest<ForgotPasswordResponse> { };

    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, ForgotPasswordResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly MediaConfiguration _mediaConfiguration;
        public ForgotPasswordCommandHandler(IUserRepository userRepository, MediaConfiguration mediaConfiguration)
        {
            _userRepository = userRepository;
            _mediaConfiguration = mediaConfiguration;
        }
        public async Task<ForgotPasswordResponse> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.SendResetPasswordLink(request.user);
        }
    }
}
