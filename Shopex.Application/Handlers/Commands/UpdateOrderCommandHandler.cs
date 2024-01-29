using MediatR;
using Shopex.Application.Extensions;
using Shopex.Application.Interfaces;
using Shopex.Domain.Configurations;
using Shopex.Domain.Enums;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record UpdateOrderCommand(long order_id, string status) : IRequest<bool> { };

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly MediaConfiguration _mediaConfiguration;
        private readonly IOrderRepository _orderRepository;
        public UpdateOrderCommandHandler(MediaConfiguration mediaConfiguration, IOrderRepository orderRepository)
        {
            _mediaConfiguration = mediaConfiguration;
            _orderRepository = orderRepository;
        }
        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            return await _orderRepository.UpdateStatus(request.order_id, request.status);
        }
    }

}
