using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.AddCommand
{
    using PsikiyatristKlinikRandevuProgrami.Core.Model;
    public class AddKullaniciCommand : ICommand
    {
        private readonly IKullaniciCommandService _commandService;
        private readonly Kullanici _kullanici;

        public AddKullaniciCommand(IKullaniciCommandService commandService, Kullanici kullanici)
        {
            _commandService = commandService;
            _kullanici = kullanici;
        }

        public void Execute()
        {
            _commandService.AddKullanici(_kullanici);
        }
    }
}
