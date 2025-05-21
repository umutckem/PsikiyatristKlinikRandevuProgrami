using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Odeme.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Odeme.Handlers
{
    public class UpdateOdemeCommandHandler : IRequestHandler<UpdateOdemeCommand, Unit>
    {
        private readonly IOdemeCommandService _commandService;

        public UpdateOdemeCommandHandler(IOdemeCommandService commandService)
        {
            _commandService = commandService;
        }

        public Task<Unit> Handle(UpdateOdemeCommand request, CancellationToken cancellationToken)
        {
            _commandService.UpdateOdeme(request.Odeme);
            return Task.FromResult(Unit.Value);
        }
    }
}
