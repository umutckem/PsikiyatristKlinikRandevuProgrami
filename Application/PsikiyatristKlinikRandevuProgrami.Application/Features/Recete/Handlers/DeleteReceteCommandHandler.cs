using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Recete.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Recete.Handlers
{
    public class DeleteReceteCommandHandler : IRequestHandler<DeleteReceteCommand, Unit>
    {
        private readonly IReceteCommandService _commandService;

        public DeleteReceteCommandHandler(IReceteCommandService commandService)
        {
            _commandService = commandService;
        }

        public Task<Unit> Handle(DeleteReceteCommand request, CancellationToken cancellationToken)
        {
            _commandService.DeleteRecete(request.ReceteId);
            return Task.FromResult(Unit.Value);
        }
    }
}
