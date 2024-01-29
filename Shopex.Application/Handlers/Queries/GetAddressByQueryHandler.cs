using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record GetAddressByQuery(int userId) : IRequest<IEnumerable<Address>> { };

    public class GetAddressByQueryHandler : IRequestHandler<GetAddressByQuery, IEnumerable<Address>>
    {
        private readonly IAddressRepository _addressRepository;

        public GetAddressByQueryHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<IEnumerable<Address>> Handle(GetAddressByQuery request, CancellationToken cancellationToken)
        {
            return await _addressRepository.GetBy(request.userId);
        }
    }

}
