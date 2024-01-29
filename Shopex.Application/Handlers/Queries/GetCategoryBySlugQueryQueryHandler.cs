using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record GetCategoryBySlugQuery(string slug) : IRequest<Categories> { };

    public class GetCategoryBySlugQueryQueryHandler : IRequestHandler<GetCategoryBySlugQuery, Categories>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryBySlugQueryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Categories> Handle(GetCategoryBySlugQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.Get(request.slug);
        }
    }

}
