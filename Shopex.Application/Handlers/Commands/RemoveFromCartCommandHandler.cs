using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Application.Extensions;
using Shopex.Domain.Configurations;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record RemoveFromCartCommand(Carts cart) : IRequest<bool> { };

    public class RemoveFromCartCommandHandler : IRequestHandler<RemoveFromCartCommand, bool>
    {
        private readonly ICartRepository _cartRepository;
        private readonly MediaConfiguration _mediaConfiguration;
        public RemoveFromCartCommandHandler(ICartRepository cartRepository, MediaConfiguration mediaConfiguration)
        {
            _cartRepository = cartRepository;
            _mediaConfiguration = mediaConfiguration;
        }
        public async Task<bool> Handle(RemoveFromCartCommand request, CancellationToken cancellationToken)
        {
            return await _cartRepository.Remove(request.cart);
        }
        
    }

}
