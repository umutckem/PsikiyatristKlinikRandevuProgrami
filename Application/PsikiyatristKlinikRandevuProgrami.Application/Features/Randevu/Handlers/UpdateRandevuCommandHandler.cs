using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Randevu.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Randevu.Handlers
{
    public class UpdateRandevuCommandHandler : IRequestHandler<UpdateRandevuCommand, Unit>
    {
        private readonly IRandevuCommandService _commandService;

        public UpdateRandevuCommandHandler(IRandevuCommandService commandService)
        {
            _commandService = commandService;
        }

        public Task<Unit> Handle(UpdateRandevuCommand request, CancellationToken cancellationToken)
        {
            _commandService.UpdateRandevu(request.Randevu);
            return Task.FromResult(Unit.Value);
        }
    }
}
