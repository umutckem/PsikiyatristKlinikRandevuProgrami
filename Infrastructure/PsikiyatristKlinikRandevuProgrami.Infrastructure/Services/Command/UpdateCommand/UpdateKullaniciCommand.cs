using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.UpdateCommand
{
    using PsikiyatristKlinikRandevuProgrami.Core.Model;
    public class UpdateKullaniciCommand : ICommand
    {
        private readonly IKullaniciCommandService _commandService;
        private readonly Kullanici _kullanici;

        public UpdateKullaniciCommand(IKullaniciCommandService commandService, Kullanici kullanici)
        {
            _commandService = commandService;
            _kullanici = kullanici;
        }

        public void Execute()
        {
            _commandService.UpdateKullanici(_kullanici);
        }
    }
}
