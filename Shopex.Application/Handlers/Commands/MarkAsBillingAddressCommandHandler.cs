using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Application.Extensions;
using Shopex.Domain.Configurations;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record MarkAsBillingAddressCommand(int address) : IRequest<bool> { };

    public class MarkAsBillingAddressCommandHandler : IRequestHandler<MarkAsBillingAddressCommand, bool>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly MediaConfiguration _mediaConfiguration;
        public MarkAsBillingAddressCommandHandler(IAddressRepository addressRepository, MediaConfiguration mediaConfiguration)
        {
            _addressRepository = addressRepository;
            _mediaConfiguration = mediaConfiguration;
        }
        public async Task<bool> Handle(MarkAsBillingAddressCommand request, CancellationToken cancellationToken)
        {
            return await _addressRepository.UpdateById(request.address);
        }
        
    }

}
