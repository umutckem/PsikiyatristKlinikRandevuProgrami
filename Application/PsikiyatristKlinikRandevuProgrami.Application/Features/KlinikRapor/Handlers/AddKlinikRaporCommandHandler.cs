using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.KlinikRapor.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.KlinikRapor.Handlers
{
    public class AddKlinikRaporCommandHandler : IRequestHandler<AddKlinikRaporCommand, Unit>
    {
        private readonly IKlinikRaporCommandService _commandService;

        public AddKlinikRaporCommandHandler(IKlinikRaporCommandService commandService)
        {
            _commandService = commandService;
        }

        public Task<Unit> Handle(AddKlinikRaporCommand request, CancellationToken cancellationToken)
        {
            _commandService.AddKlinikRapor(request.KlinikRapor);
            return Task.FromResult(Unit.Value); // Geriye Unit döndür
        }
    }
}
