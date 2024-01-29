using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record GetCategoryQuery(int categoryId) : IRequest<Categories> { };

    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Categories>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Categories> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.Get(request.categoryId);
        }
    }

}
