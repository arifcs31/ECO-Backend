using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Domain.Feed;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record UploadProductPricesCommand(string filePath, FileStream fs) : IRequest<bool> { };

    public class UploadProductPricesCommandHandler : IRequestHandler<UploadProductPricesCommand, bool>
    {
        private readonly IProductPricesRepository _productPriceRepository;
        private readonly IFeedProductPriceTransformer _feedTransformer;
        public UploadProductPricesCommandHandler(IProductPricesRepository productPriceRepository, IFeedProductPriceTransformer feedTransformer)
        {
            _feedTransformer = feedTransformer;
            _productPriceRepository = productPriceRepository;
        }
        public async Task<bool> Handle(UploadProductPricesCommand request, CancellationToken cancellationToken)
        {
            var fileBytes = File.ReadAllBytes(request.filePath);
            using (FileStream fileStream = new FileStream(request.filePath, FileMode.Create))
            {
                for (int i = 0; i < fileBytes.Length; i++)
                {
                    fileStream.WriteByte(fileBytes[i]);
                }

                fileStream.Seek(0, SeekOrigin.Begin);
                IEnumerable<ProductPriceFeedModel> result = await _feedTransformer.TransformProductPrices(fileStream);

                var dbList = result.Select(product => new ProductPrices()
                {
                    is_active = product.is_active,
                    created = DateTime.UtcNow,
                    pack_range = product.pack_range,
                    price = Convert.ToDecimal(product.price),
                    external_product_id = product.upc,
                    size1 = product.size1,
                    size2 = product.size2
                });
                await _productPriceRepository.BulkImport(dbList);
            }
            return true;
        }
    }

}
