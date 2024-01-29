using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopex.Application.Handlers.Queries;
using Shopex.Domain.Configurations;
using Shopex.Domain.Dto;
using System.Net.Http.Headers;
using Banners = Shopex.Domain.Model.Banners;

namespace Shopex.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly MediaConfiguration _mediaConfiguration;
        private readonly ILogger<BannersController> _logger;

        public BannersController(ILogger<BannersController> logger, IMediator mediator, MediaConfiguration mediaConfiguration)
        {
            _logger = logger;
            _mediator = mediator;
            _mediaConfiguration = mediaConfiguration;
        }

        [HttpGet]
        public async Task<BannerResponseDto> Get([FromQuery] DataFilterDto query)
        {
            return await _mediator.Send(new GetBannersQuery(query));
        }
        [HttpGet]
        [Route("{bannerId}")]
        public async Task<Banners> Get(int bannerId)
        {
            return await _mediator.Send(new GetBannerQuery(bannerId));
        }
        [HttpPost]
        public async Task<bool> Add([FromBody] Banners banner)
        {
            return await _mediator.Send(new AddBannerCommand(banner));
        }
        [HttpPut]
        public async Task<bool> Update([FromBody] Banners banner)
        {
            return await _mediator.Send(new UpdateBannerCommand(banner));
        }
        [Route("[action]")]
        [HttpPost, DisableRequestSizeLimit]
        public async Task<bool> Upload(int bannerId)
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
                    var fileName = $"{bannerId}.{ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"').Split('.')[1]}";
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(_mediaConfiguration.HostingPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return await _mediator.Send(new UpdateBannerImageCommand(bannerId, $"{dbPath}"));

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
    }
}
