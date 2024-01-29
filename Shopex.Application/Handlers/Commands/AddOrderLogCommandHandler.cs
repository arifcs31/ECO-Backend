using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Domain.Configurations;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record AddOrderLogCommand(OrderLogs order) : IRequest<bool> { };

    public class AddOrderLogCommandHandler : IRequestHandler<AddOrderLogCommand, bool>
    {
        private readonly IOrderLogRepository _orderRepository;
        private readonly MediaConfiguration _mediaConfiguration;
        public AddOrderLogCommandHandler(IOrderLogRepository orderRepository, MediaConfiguration mediaConfiguration)
        {
            _orderRepository = orderRepository;
            _mediaConfiguration = mediaConfiguration;
        }
        public async Task<bool> Handle(AddOrderLogCommand request, CancellationToken cancellationToken)
        {
            bool result = await _orderRepository.Add(request.order);

            return result;
        }
        
    }

}
