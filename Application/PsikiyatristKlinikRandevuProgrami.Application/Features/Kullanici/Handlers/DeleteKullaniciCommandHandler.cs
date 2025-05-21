using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Kullanici.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Kullanici.Handlers
{
    public class DeleteKullaniciCommandHandler : IRequestHandler<DeleteKullaniciCommand, Unit>
    {
        private readonly IKullaniciCommandService _commandService;

        public DeleteKullaniciCommandHandler(IKullaniciCommandService commandService)
        {
            _commandService = commandService;
        }

        public async Task<Unit> Handle(DeleteKullaniciCommand request, CancellationToken cancellationToken)
        {
            await _commandService.DeleteKullanici(request.KullaniciId);
            return Unit.Value;
        }
    }
}
