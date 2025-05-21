using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Recete.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Recete.Handlers
{
    public class UpdateReceteCommandHandler : IRequestHandler<UpdateReceteCommand, Unit>
    {
        private readonly IReceteCommandService _commandService;

        public UpdateReceteCommandHandler(IReceteCommandService commandService)
        {
            _commandService = commandService;
        }

        public Task<Unit> Handle(UpdateReceteCommand request, CancellationToken cancellationToken)
        {
            _commandService.UpdateRecete(request.Recete);
            return Task.FromResult(Unit.Value);
        }
    }
}
