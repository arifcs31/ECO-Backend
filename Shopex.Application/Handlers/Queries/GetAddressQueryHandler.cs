using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record GetAddressQuery(int addressId) : IRequest<Address> { };

    public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, Address>
    {
        private readonly IAddressRepository _addressRepository;

        public GetAddressQueryHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<Address> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            return await _addressRepository.Get(request.addressId);
        }
    }

}
