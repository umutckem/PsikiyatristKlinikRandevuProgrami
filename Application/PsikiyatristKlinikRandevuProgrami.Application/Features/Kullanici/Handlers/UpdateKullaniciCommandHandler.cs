using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Kullanici.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Kullanici.Handlers
{
    public class UpdateKullaniciCommandHandler : IRequestHandler<UpdateKullaniciCommand, Unit>
    {
        private readonly IKullaniciCommandService _commandService;

        public UpdateKullaniciCommandHandler(IKullaniciCommandService commandService)
        {
            _commandService = commandService;
        }

        public async Task<Unit> Handle(UpdateKullaniciCommand request, CancellationToken cancellationToken)
        {
            await _commandService.UpdateKullanici(request.Kullanici);
            return Unit.Value;
        }
    }
}
