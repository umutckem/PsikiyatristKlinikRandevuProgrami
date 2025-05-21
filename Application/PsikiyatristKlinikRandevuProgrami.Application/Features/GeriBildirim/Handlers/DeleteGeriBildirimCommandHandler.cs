using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.GeriBildirim.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.GeriBildirim.Handlers
{
    public class DeleteGeriBildirimCommandHandler : IRequestHandler<DeleteGeriBildirimCommand, Unit>
    {
        private readonly IGeriBildirimCommandService _service;

        public DeleteGeriBildirimCommandHandler(IGeriBildirimCommandService service)
        {
            _service = service;
        }

        public Task<Unit> Handle(DeleteGeriBildirimCommand request, CancellationToken cancellationToken)
        {
            _service.DeleteGeriBildirim(request.GeriBildirimId);
            return Task.FromResult(Unit.Value);
        }
    }
}
