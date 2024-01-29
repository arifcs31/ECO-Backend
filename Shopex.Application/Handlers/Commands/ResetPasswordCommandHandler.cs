using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record ResetPasswordCommand(int userId, string password) : IRequest<bool> { };

    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public ResetPasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.UpdatePassword(request.userId, request.password);
        }
    }

}
