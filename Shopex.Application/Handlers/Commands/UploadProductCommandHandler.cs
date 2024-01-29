using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Domain.Feed;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record UploadProductCommand(string filePath, FileStream fs) : IRequest<bool> { };

    public class UploadProductCommandHandler : IRequestHandler<UploadProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IFeedProductTransformer _feedTransformer;
        public UploadProductCommandHandler(IProductRepository productRepository, IFeedProductTransformer feedTransformer)
        {
            _feedTransformer = feedTransformer;
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(UploadProductCommand request, CancellationToken cancellationToken)
        {
            var fileBytes = File.ReadAllBytes(request.filePath);
            using (FileStream fileStream = new FileStream(request.filePath, FileMode.Create))
            {
                for (int i = 0; i < fileBytes.Length; i++)
                {
                    fileStream.WriteByte(fileBytes[i]);
                }

                fileStream.Seek(0, SeekOrigin.Begin);
                IEnumerable<ProductFeedModel> result = await _feedTransformer.TransformProducts(fileStream);

                var dbList = result.Select(product => new Products()
                {
                    external_category_id = product.category_id,
                    name = product.name,
                    description = product.description,
                    is_active = product.is_active,
                    brand = product.brand,
                    external_id = product.product_id,
                    price = product.price,
                    uses = product.uses,
                    tech_description = product.tech_description,
                    upc = product.upc,
                    show_on_landing = product.show_on_landing,
                    sort = !String.IsNullOrEmpty(product.sort) ? Convert.ToInt32(product.sort) : 0,
                    link_upc = product.link_upc,
                });
                await _productRepository.BulkImport(dbList);
            }
            return true;
        }
    }

}
