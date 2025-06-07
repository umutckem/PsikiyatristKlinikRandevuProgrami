using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.DeleteCommand
{
    public class DeleteKlinikRaporCommand : ICommand
    {
        private readonly IKlinikRaporCommandService _commandService;
        private readonly int _klinikRaporId;

        public DeleteKlinikRaporCommand(IKlinikRaporCommandService commandService, int klinikRaporId)
        {
            _commandService = commandService;
            _klinikRaporId = klinikRaporId;
        }

        public void Execute()
        {
            _commandService.DeleteKlinikRapor(_klinikRaporId);
        }
    }
}
