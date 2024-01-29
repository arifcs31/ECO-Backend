using MediatR;
using Shopex.Application.Interfaces;
using Shopex.Application.Extensions;
using Shopex.Domain.Configurations;
using Shopex.Domain.Model;

namespace Shopex.Application.Handlers.Queries
{
    public record CreateSessionCommand(Sessions session) : IRequest<long> { };

    public class CreateSessionCommandHandler : IRequestHandler<CreateSessionCommand, long>
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly MediaConfiguration _mediaConfiguration;
        public CreateSessionCommandHandler(ISessionRepository sessionRepository, MediaConfiguration mediaConfiguration)
        {
            _sessionRepository = sessionRepository;
            _mediaConfiguration = mediaConfiguration;
        }
        public async Task<long> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
        {
            return await _sessionRepository.Create(request.session);
        }
        
    }

}
