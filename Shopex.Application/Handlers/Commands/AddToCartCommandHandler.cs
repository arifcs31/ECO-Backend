using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Application.Extensions;
using Shopex.Domain.Configurations;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record AddToCartCommand(Carts cart) : IRequest<bool> { };

    public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, bool>
    {
        private readonly ICartRepository _cartRepository;
        private readonly MediaConfiguration _mediaConfiguration;
        public AddToCartCommandHandler(ICartRepository cartRepository, MediaConfiguration mediaConfiguration)
        {
            _cartRepository = cartRepository;
            _mediaConfiguration = mediaConfiguration;
        }
        public async Task<bool> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            return await _cartRepository.Add(request.cart);
        }
        
    }

}
