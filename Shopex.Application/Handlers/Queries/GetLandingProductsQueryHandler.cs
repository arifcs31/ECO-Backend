using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Domain.Dto;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record GetLandingProductsQuery(DataFilterDto query) : IRequest<IEnumerable<Products>> { };

    public class GetLandingProductsQueryHandler : IRequestHandler<GetLandingProductsQuery, IEnumerable<Products>>
    {
        private readonly IProductRepository _productRepository;

        public GetLandingProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Products>> Handle(GetLandingProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetLanding(request.query);
        }
    }

}
