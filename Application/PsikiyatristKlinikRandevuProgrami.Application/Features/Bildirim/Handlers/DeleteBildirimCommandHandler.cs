using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Features.Bildirim.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Features.Bildirim.Handlers
{
    public class DeleteBildirimCommandHandler : IRequestHandler<DeleteBildirimCommand, Unit>
    {
        private readonly IBildirimCommandService _bildirimCommandService;

        public DeleteBildirimCommandHandler(IBildirimCommandService bildirimCommandService)
        {
            _bildirimCommandService = bildirimCommandService;
        }

        public Task<Unit> Handle(DeleteBildirimCommand request, CancellationToken cancellationToken)
        {
            _bildirimCommandService.DeleteBildirim(request.BildirimId);
            return Task.FromResult(Unit.Value);
        }
    }
}
