using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Recete.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Recete.Handlers
{
    public class AddReceteCommandHandler : IRequestHandler<AddReceteCommand, Unit>
    {
        private readonly IReceteCommandService _commandService;

        public AddReceteCommandHandler(IReceteCommandService commandService)
        {
            _commandService = commandService;
        }

        public Task<Unit> Handle(AddReceteCommand request, CancellationToken cancellationToken)
        {
            _commandService.AddRecete(request.Recete);
            return Task.FromResult(Unit.Value);
        }
    }
}
