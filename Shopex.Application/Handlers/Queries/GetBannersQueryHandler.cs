using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Domain.Dto;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record GetBannersQuery(DataFilterDto query) : IRequest<BannerResponseDto> { };

    public class GetBannersQueryHandler : IRequestHandler<GetBannersQuery, BannerResponseDto>
    {
        private readonly IBannerRepository _bannerRepository;

        public GetBannersQueryHandler(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }
        public async Task<BannerResponseDto> Handle(GetBannersQuery request, CancellationToken cancellationToken)
        {
            return await _bannerRepository.Get(request.query);
        }
    }

}
