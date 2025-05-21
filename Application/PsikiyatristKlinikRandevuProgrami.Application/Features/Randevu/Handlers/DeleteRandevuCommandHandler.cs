using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Randevu.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Randevu.Handlers
{
    public class DeleteRandevuCommandHandler : IRequestHandler<DeleteRandevuCommand, Unit>
    {
        private readonly IRandevuCommandService _commandService;

        public DeleteRandevuCommandHandler(IRandevuCommandService commandService)
        {
            _commandService = commandService;
        }

        public Task<Unit> Handle(DeleteRandevuCommand request, CancellationToken cancellationToken)
        {
            _commandService.DeleteRandevu(request.RandevuId);
            return Task.FromResult(Unit.Value);
        }
    }
}
