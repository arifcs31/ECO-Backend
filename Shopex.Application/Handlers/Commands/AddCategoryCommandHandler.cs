using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record AddCategoryCommand(Categories category) : IRequest<bool> { };

    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        public AddCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<bool> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.Add(request.category);
        }
    }

}
