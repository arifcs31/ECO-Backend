using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Application.Extensions;
using Shopex.Domain.Configurations;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record AddBannerCommand(Banners banner) : IRequest<bool> { };

    public class AddBannerCommandHandler : IRequestHandler<AddBannerCommand, bool>
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly MediaConfiguration _mediaConfiguration;
        public AddBannerCommandHandler(IBannerRepository bannerRepository, MediaConfiguration mediaConfiguration)
        {
            _bannerRepository = bannerRepository;
            _mediaConfiguration = mediaConfiguration;
        }
        public async Task<bool> Handle(AddBannerCommand request, CancellationToken cancellationToken)
        {
            request.banner.image_url = request.banner.image_url.SaveFile(_mediaConfiguration);
            return await _bannerRepository.Add(request.banner);
        }
        
    }

}
