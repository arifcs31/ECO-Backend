using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopex.Application.Handlers.Queries;
using Shopex.Domain.Configurations;
using Shopex.Domain.Dto;
using Shopex.Domain.Model;
using System.IO;
using System.Net.Http.Headers;

namespace Shopex.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly MediaConfiguration _mediaConfiguration;
        private readonly ILogger<ProductsController> _logger;
        static List<Products>  products = new List<Products>();
        public ProductsController(ILogger<ProductsController> logger, IMediator mediator, MediaConfiguration mediaConfiguration)
        {
            _logger = logger;
            _mediator = mediator;
            _mediaConfiguration = mediaConfiguration;
        }
        [HttpGet]
        public async Task<IEnumerable<Products>> Get([FromQuery] DataFilterDto query)
        {
            return await _mediator.Send(new GetProductsQuery(query));
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<Products>> GetLanding([FromQuery] DataFilterDto query)
        {
            if(products.Any())
            {
                return products;
            }
            var result = await _mediator.Send(new GetLandingProductsQuery(query));
            products = result.ToList();
            return result;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<Products>> Search([FromQuery] DataFilterDto query)
        {
            return await _mediator.Send(new GetSearchProductsQuery(query));
        }
        //[HttpPost]
        //public async Task<bool> Add([FromBody]Categories category)
        //{
        //    return await _mediator.Send(new AddCategoryCommand(category));
        //}
        [Route("[action]")]
        [HttpPost, DisableRequestSizeLimit]
        public async Task<bool> Upload(int userId)
        {
            try
            {
                var file = Request.Form.Files[0];
                var pathToSave = _mediaConfiguration.FtpPath;
                if (!Directory.Exists(pathToSave))
                {
                    Directory.CreateDirectory(pathToSave);
                }
                if (file.Length > 0)
                {
                    var fileName = $"{userId}.product.{ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"').Split('.')[1]}";
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(_mediaConfiguration.HostingPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);

                    }
                    await _mediator.Send(new UploadProductCommand(fullPath,null));
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal server error: {ex}");
                return false;
            }
        }
        [Route("[action]")]
        [HttpPost, DisableRequestSizeLimit]
        public async Task<bool> UploadPrices(int userId)
        {
            try
            {
                var file = Request.Form.Files[0];
                var pathToSave = _mediaConfiguration.FtpPath;
                if (!Directory.Exists(pathToSave))
                {
                    Directory.CreateDirectory(pathToSave);
                }
                if (file.Length > 0)
                {
                    var fileName = $"{userId}.prices.{ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"').Split('.')[1]}";
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(_mediaConfiguration.HostingPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);

                    }
                    await _mediator.Send(new UploadProductPricesCommand(fullPath, null));
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal server error: {ex}");
                return false;
            }
        }
        [HttpGet]
        [Route("[action]/{productId}")]
        public async Task<Products> GetById(int productId)
        {
            return await _mediator.Send(new GetProductQuery(productId));
        }

        //[HttpPut]
        //public async Task<bool> Update([FromBody] Banners banner)
        //{
        //    return await _mediator.Send(new UpdateCa(banner));
        //}
    }
}
