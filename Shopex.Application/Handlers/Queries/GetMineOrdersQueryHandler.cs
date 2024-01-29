using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Domain.Dto;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record GetMineOrdersQuery(DataFilterDto query) : IRequest<OrderResponseDto> { };

    public class GetMineOrdersQueryHandler : IRequestHandler<GetMineOrdersQuery, OrderResponseDto>
    {
        private readonly IOrderRepository _orderRepository;

        public GetMineOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OrderResponseDto> Handle(GetMineOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetMine(request.query);
        }
    }

}
