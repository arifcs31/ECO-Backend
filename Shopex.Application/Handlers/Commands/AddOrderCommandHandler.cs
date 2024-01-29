using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Application.Extensions;
using Shopex.Domain.Configurations;
using Shopex.Domain.Model;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Shopex.Application.Handlers.Queries
{
    public record AddOrderCommand(Orders order) : IRequest<long> { };

    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, long>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly MediaConfiguration _mediaConfiguration;
        public AddOrderCommandHandler(ICartRepository cartRepository,IOrderRepository orderRepository, MediaConfiguration mediaConfiguration)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
            _mediaConfiguration = mediaConfiguration;
        }
        public async Task<long> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            long result = await _orderRepository.Add(request.order);

            await _cartRepository.Deactivate((int)request.order.user_id);

            return result;
        }
        
    }

}
