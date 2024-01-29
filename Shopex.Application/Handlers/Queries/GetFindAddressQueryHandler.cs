using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Domain.Dto;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record GetFindAddressQuery(string search,string postCode) : IRequest<AddressResult> { };

    public class GetFindAddressQueryHandler : IRequestHandler<GetFindAddressQuery, AddressResult>
    {
        private readonly IFindAddressPartyService _findAddressPartyService;

        public GetFindAddressQueryHandler(IFindAddressPartyService findAddressPartyService)
        {
            _findAddressPartyService = findAddressPartyService;
        }
        public async Task<AddressResult> Handle(GetFindAddressQuery request, CancellationToken cancellationToken)
        {
            return await _findAddressPartyService.FindAddress("postcodes", request.postCode);
        }
    }

}
