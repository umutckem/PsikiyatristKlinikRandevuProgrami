using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Odeme.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Odeme.Handlers
{
    public class DeleteOdemeCommandHandler : IRequestHandler<DeleteOdemeCommand, Unit>
    {
        private readonly IOdemeCommandService _commandService;

        public DeleteOdemeCommandHandler(IOdemeCommandService commandService)
        {
            _commandService = commandService;
        }

        public Task<Unit> Handle(DeleteOdemeCommand request, CancellationToken cancellationToken)
        {
            _commandService.DeleteOdeme(request.OdemeId);
            return Task.FromResult(Unit.Value);
        }
    }
}
