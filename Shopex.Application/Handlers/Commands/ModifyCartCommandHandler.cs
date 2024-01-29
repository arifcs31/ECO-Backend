using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Application.Extensions;
using Shopex.Domain.Configurations;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record ModifyCartCommand(Carts cart) : IRequest<bool> { };

    public class ModifyCartCommandHandler : IRequestHandler<ModifyCartCommand, bool>
    {
        private readonly ICartRepository _cartRepository;
        private readonly MediaConfiguration _mediaConfiguration;
        public ModifyCartCommandHandler(ICartRepository cartRepository, MediaConfiguration mediaConfiguration)
        {
            _cartRepository = cartRepository;
            _mediaConfiguration = mediaConfiguration;
        }
        public async Task<bool> Handle(ModifyCartCommand request, CancellationToken cancellationToken)
        {
            return await _cartRepository.ModifyCart(request.cart.cart_id,(int)request.cart.count);
        }
        
    }

}
