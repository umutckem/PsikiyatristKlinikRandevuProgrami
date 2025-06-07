using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.DeleteCommand
{
    public class DeleteKullaniciCommand : ICommand
    {
        private readonly IKullaniciCommandService _commandService;
        private readonly int _kullaniciId;

        public DeleteKullaniciCommand(IKullaniciCommandService commandService, int kullaniciId)
        {
            _commandService = commandService;
            _kullaniciId = kullaniciId;
        }

        public void Execute()
        {
            _commandService.DeleteKullanici(_kullaniciId);
        }
    }
}
