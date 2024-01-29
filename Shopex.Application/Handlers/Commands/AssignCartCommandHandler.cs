using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Application.Extensions;
using Shopex.Domain.Configurations;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record AssignCartCommand(long anonymousUserId,int userId) : IRequest<bool> { };

    public class AssignCartCommandHandler : IRequestHandler<AssignCartCommand, bool>
    {
        private readonly ICartRepository _cartRepostiroy;
        private readonly MediaConfiguration _mediaConfiguration;
        public AssignCartCommandHandler(ICartRepository cartRepostiroy, MediaConfiguration mediaConfiguration)
        {
            _cartRepostiroy = cartRepostiroy;
            _mediaConfiguration = mediaConfiguration;
        }
        public async Task<bool> Handle(AssignCartCommand request, CancellationToken cancellationToken)
        {

            return await _cartRepostiroy.AssignCart(request.anonymousUserId, request.userId);
        }
        
    }

}
