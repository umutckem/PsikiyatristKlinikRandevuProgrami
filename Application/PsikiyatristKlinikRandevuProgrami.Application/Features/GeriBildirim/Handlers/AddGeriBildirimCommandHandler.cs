using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.GeriBildirim.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.GeriBildirim.Handlers
{
    public class AddGeriBildirimCommandHandler : IRequestHandler<AddGeriBildirimCommand, Unit>
    {
        private readonly IGeriBildirimCommandService _service;

        public AddGeriBildirimCommandHandler(IGeriBildirimCommandService service)
        {
            _service = service;
        }

        public Task<Unit> Handle(AddGeriBildirimCommand request, CancellationToken cancellationToken)
        {
            _service.AddGeriBildirim(request.GeriBildirim);
            return Task.FromResult(Unit.Value); // Doğru dönüş tipi
        }
    }
}
