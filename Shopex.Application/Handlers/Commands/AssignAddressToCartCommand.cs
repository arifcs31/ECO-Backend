using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Domain.Configurations;

namespace Shopex.Application.Handlers.Queries
{
    public record AssignAddressToCartCommand(int addressId,int cartId) : IRequest<bool> { };

    public class AssignAddressToCartCommandHandler : IRequestHandler<AssignAddressToCartCommand, bool>
    {
        private readonly ICartRepository _cartRepostiroy;
        private readonly MediaConfiguration _mediaConfiguration;
        public AssignAddressToCartCommandHandler(ICartRepository cartRepostiroy, MediaConfiguration mediaConfiguration)
        {
            _cartRepostiroy = cartRepostiroy;
            _mediaConfiguration = mediaConfiguration;
        }
        public async Task<bool> Handle(AssignAddressToCartCommand request, CancellationToken cancellationToken)
        {

            return await _cartRepostiroy.AssignAddressToCart(request.addressId, request.cartId);
        }
        
    }

}
