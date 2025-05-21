using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.KlinikRapor.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using System.Threading;
using System.Threading.Tasks;
using PsikiyatristKlinikRandevuProgrami.Application.Commands.KlinikRapor;

namespace PsikiyatristKlinikRandevuProgrami.Application.KlinikRapor.Handlers
{
    public class DeleteKlinikRaporCommandHandler : IRequestHandler<DeleteKlinikRaporCommand, Unit>
    {
        private readonly IKlinikRaporCommandService _commandService;

        public DeleteKlinikRaporCommandHandler(IKlinikRaporCommandService commandService)
        {
            _commandService = commandService;
        }

        public Task<Unit> Handle(DeleteKlinikRaporCommand request, CancellationToken cancellationToken)
        {
            _commandService.DeleteKlinikRapor(request.KlinikRaporId);
            return Task.FromResult(Unit.Value);
        }
    }
}
