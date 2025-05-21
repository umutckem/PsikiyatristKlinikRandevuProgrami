using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Features.Bildirim.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Features.Bildirim.Handlers
{
    public class UpdateBildirimCommandHandler : IRequestHandler<UpdateBildirimCommand, Unit>
    {
        private readonly IBildirimCommandService _bildirimCommandService;

        public UpdateBildirimCommandHandler(IBildirimCommandService bildirimCommandService)
        {
            _bildirimCommandService = bildirimCommandService;
        }

        public Task<Unit> Handle(UpdateBildirimCommand request, CancellationToken cancellationToken)
        {
            _bildirimCommandService.UpdateBildirim(request.Bildirim);
            return Task.FromResult(Unit.Value);
        }
    }
}
