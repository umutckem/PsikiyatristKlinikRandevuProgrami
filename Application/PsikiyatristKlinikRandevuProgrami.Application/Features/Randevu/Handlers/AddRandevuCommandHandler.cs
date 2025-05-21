using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Randevu.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Randevu.Handlers
{
    public class AddRandevuCommandHandler : IRequestHandler<AddRandevuCommand, Unit>
    {
        private readonly IRandevuCommandService _commandService;

        public AddRandevuCommandHandler(IRandevuCommandService commandService)
        {
            _commandService = commandService;
        }

        public Task<Unit> Handle(AddRandevuCommand request, CancellationToken cancellationToken)
        {
            _commandService.AddRandevu(request.Randevu);
            return Task.FromResult(Unit.Value);
        }
    }
}
