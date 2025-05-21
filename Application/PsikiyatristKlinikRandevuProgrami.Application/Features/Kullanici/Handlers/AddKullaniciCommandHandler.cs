using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Kullanici.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Kullanici.Handlers
{
    public class AddKullaniciCommandHandler : IRequestHandler<AddKullaniciCommand, Unit>
    {
        private readonly IKullaniciCommandService _commandService;

        public AddKullaniciCommandHandler(IKullaniciCommandService commandService)
        {
            _commandService = commandService;
        }

        public async Task<Unit> Handle(AddKullaniciCommand request, CancellationToken cancellationToken)
        {
            await _commandService.AddKullanici(request.Kullanici);
            return Unit.Value;
        }
    }
}
