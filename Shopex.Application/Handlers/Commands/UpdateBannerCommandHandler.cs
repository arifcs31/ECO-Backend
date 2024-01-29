using MediatR;
using Shopex.Application.Extensions;
using Shopex.Application.Interfaces;
using Shopex.Domain.Configurations;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record UpdateBannerCommand(Banners banner) : IRequest<bool> { };

    public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommand, bool>
    {
        private readonly MediaConfiguration _mediaConfiguration;
        private readonly IBannerRepository _bannerRepository;
        public UpdateBannerCommandHandler(MediaConfiguration mediaConfiguration, IBannerRepository bannerRepository)
        {
            _mediaConfiguration = mediaConfiguration;
            _bannerRepository = bannerRepository;
        }
        public async Task<bool> Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            request.banner.image_url = request.banner.image_url.SaveFile(_mediaConfiguration);
            return await _bannerRepository.Update(request.banner);
        }
    }

}
