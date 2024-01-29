using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Domain.Feed;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record UploadCategoryCommand(string filePath, FileStream fs) : IRequest<bool> { };

    public class UploadCategoryCommandHandler : IRequestHandler<UploadCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFeedTransformer _feedTransformer;
        public UploadCategoryCommandHandler(ICategoryRepository categoryRepository, IFeedTransformer feedTransformer)
        {
            _feedTransformer = feedTransformer;
            _categoryRepository = categoryRepository;
        }
        public async Task<bool> Handle(UploadCategoryCommand request, CancellationToken cancellationToken)
        {
            //var fileBytes = File.ReadAllBytes(request.filePath);
            //using (FileStream fileStream = new FileStream(request.filePath, FileMode.Create))
            //{
            //    for (int i = 0; i < fileBytes.Length; i++)
            //    {
            //        fileStream.WriteByte(fileBytes[i]);
            //    }

            //    fileStream.Seek(0, SeekOrigin.Begin);
                IEnumerable<CategoryFeedModel> result = await _feedTransformer.TransformCategory(request.fs);

            var dbList = result.Select(category => new Categories()
            {
                external_id = category.category_id,
                name = category.name,
                description = category.description,
                is_active = category.status,
                slug = category?.name?.Trim()?.Replace("$", "").Replace("-","").Replace(")", "").Replace("(","").Replace("\\", "").Replace("/","").Replace(" ", "-")?.ToLower(),
                order = category.sort,
                external_parent_id = category.parent_id
            }) ;
                await _categoryRepository.BulkImport(dbList);

                
           // }
            return true;
        }
    }

}
