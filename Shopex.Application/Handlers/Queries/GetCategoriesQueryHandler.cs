using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record GetCategoriesQuery : IRequest<IEnumerable<Categories>> { };

    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<Categories>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Categories>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.Get();
        }
    }

}
