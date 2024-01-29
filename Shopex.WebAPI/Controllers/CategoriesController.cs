using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopex.Application.Handlers.Queries;
using Shopex.Domain.Configurations;
using Shopex.Domain.Model;
using System.Net.Http.Headers;

namespace Shopex.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly MediaConfiguration _mediaConfiguration;
        private readonly ILogger<CategoriesController> _logger;
        public static List<Categories> list = new  List<Categories>();
        public CategoriesController(ILogger<CategoriesController> logger, IMediator mediator, MediaConfiguration mediaConfiguration)
        {
            _logger = logger;
            _mediator = mediator;
            _mediaConfiguration = mediaConfiguration;
        }

        [HttpGet]
        public async Task<IEnumerable<Categories>> Get()
        {
            var req = Request.QueryString;
            //if (Request.Headers["User-Agent"].ToString().Contains("node"))
            //{
            //   list
            //}
            if(list.Any())
            {
                return list;
            }
            var result = await _mediator.Send(new GetCategoriesQuery());
            list = result.ToList();
            return result; 
        }
        [HttpPost]
        public async Task<bool> Add([FromBody]Categories category)
        {
            return await _mediator.Send(new AddCategoryCommand(category));
        }
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
                    var fileName = $"{userId}.{ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"').Split('.')[1]}";
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(_mediaConfiguration.HostingPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        await _mediator.Send(new UploadCategoryCommand(fullPath, stream));
                    }
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
        [Route("{categoryId}")]
        public async Task<Categories> Get(int categoryId)
        {
            return await _mediator.Send(new GetCategoryQuery(categoryId));
        }
        [HttpGet]
        [Route("[action]/{slug}")]
        public async Task<Categories> GetBySlug(string slug)
        {
            return await _mediator.Send(new GetCategoryBySlugQuery(slug));
        }
        //[HttpPut]
        //public async Task<bool> Update([FromBody] Banners banner)
        //{
        //    return await _mediator.Send(new UpdateCa(banner));
        //}
    }
}
