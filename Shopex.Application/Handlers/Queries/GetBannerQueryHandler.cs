using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record GetBannerQuery(int bannerId) : IRequest<Banners> { };

    public class GetBannerQueryHandler : IRequestHandler<GetBannerQuery, Banners>
    {
        private readonly IBannerRepository _bannerRepository;

        public GetBannerQueryHandler(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }
        public async Task<Banners> Handle(GetBannerQuery request, CancellationToken cancellationToken)
        {
            return await _bannerRepository.Get(request.bannerId);
        }
    }

}
