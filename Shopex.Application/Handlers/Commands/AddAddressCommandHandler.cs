using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Application.Extensions;
using Shopex.Domain.Configurations;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record AddAddressCommand(Address address) : IRequest<bool> { };

    public class AddAddressCommandHandler : IRequestHandler<AddAddressCommand, bool>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly MediaConfiguration _mediaConfiguration;
        public AddAddressCommandHandler(IAddressRepository addressRepository, MediaConfiguration mediaConfiguration)
        {
            _addressRepository = addressRepository;
            _mediaConfiguration = mediaConfiguration;
        }
        public async Task<bool> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            return await _addressRepository.Add(request.address);
        }
        
    }

}
