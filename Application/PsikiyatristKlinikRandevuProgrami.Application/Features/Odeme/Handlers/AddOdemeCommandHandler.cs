using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Odeme.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Odeme.Handlers
{
    public class AddOdemeCommandHandler : IRequestHandler<AddOdemeCommand, Unit>
    {
        private readonly IOdemeCommandService _commandService;

        public AddOdemeCommandHandler(IOdemeCommandService commandService)
        {
            _commandService = commandService;
        }

        public Task<Unit> Handle(AddOdemeCommand request, CancellationToken cancellationToken)
        {
            _commandService.AddOdeme(request.Odeme);
            return Task.FromResult(Unit.Value);
        }
    }
}
