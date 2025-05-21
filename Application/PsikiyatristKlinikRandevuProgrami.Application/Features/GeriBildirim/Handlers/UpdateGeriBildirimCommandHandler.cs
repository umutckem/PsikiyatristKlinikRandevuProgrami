using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.GeriBildirim.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.GeriBildirim.Handlers
{
    public class UpdateGeriBildirimCommandHandler : IRequestHandler<UpdateGeriBildirimCommand, Unit>
    {
        private readonly IGeriBildirimCommandService _service;

        public UpdateGeriBildirimCommandHandler(IGeriBildirimCommandService service)
        {
            _service = service;
        }

        public Task<Unit> Handle(UpdateGeriBildirimCommand request, CancellationToken cancellationToken)
        {
            _service.UpdateGeriBildirim(request.GeriBildirim);
            return Task.FromResult(Unit.Value);
        }
    }
}
