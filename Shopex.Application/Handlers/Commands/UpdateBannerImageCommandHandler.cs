using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record UpdateBannerImageCommand(int bannerId, string image_url) : IRequest<bool> { };

    public class UpdateBannerImageCommandHandler : IRequestHandler<UpdateBannerImageCommand, bool>
    {
        private readonly IBannerRepository _bannerRepository;
        public UpdateBannerImageCommandHandler(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }
        public async Task<bool> Handle(UpdateBannerImageCommand request, CancellationToken cancellationToken)
        {
            return await _bannerRepository.UpdateImage(request.bannerId, request.image_url);
        }
    }

}
