using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.KlinikRapor.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using System.Threading;
using System.Threading.Tasks;
using PsikiyatristKlinikRandevuProgrami.Application.Commands.KlinikRapor;

namespace PsikiyatristKlinikRandevuProgrami.Application.KlinikRapor.Handlers
{
    public class UpdateKlinikRaporCommandHandler : IRequestHandler<UpdateKlinikRaporCommand, Unit>
    {
        private readonly IKlinikRaporCommandService _commandService;

        public UpdateKlinikRaporCommandHandler(IKlinikRaporCommandService commandService)
        {
            _commandService = commandService;
        }

        public Task<Unit> Handle(UpdateKlinikRaporCommand request, CancellationToken cancellationToken)
        {
            _commandService.UpdateKlinikRapor(request.KlinikRapor);
            return Task.FromResult(Unit.Value);
        }
    }
}

