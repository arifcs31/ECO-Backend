using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Application.Extensions;
using Shopex.Domain.Configurations;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record UpdateAddressCommand(Address address) : IRequest<bool> { };

    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, bool>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly MediaConfiguration _mediaConfiguration;
        public UpdateAddressCommandHandler(IAddressRepository addressRepository, MediaConfiguration mediaConfiguration)
        {
            _addressRepository = addressRepository;
            _mediaConfiguration = mediaConfiguration;
        }
        public async Task<bool> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            return await _addressRepository.Update(request.address);
        }
        
    }

}
