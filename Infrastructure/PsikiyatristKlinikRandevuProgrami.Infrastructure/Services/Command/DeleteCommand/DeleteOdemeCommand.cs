using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.DeleteCommand
{
    public class DeleteOdemeCommand : ICommand
    {
        private readonly IOdemeCommandService _commandService;
        private readonly int _odemeId;

        public DeleteOdemeCommand(IOdemeCommandService commandService, int odemeId)
        {
            _commandService = commandService;
            _odemeId = odemeId;
        }

        public void Execute()
        {
            _commandService.DeleteOdeme(_odemeId);
        }
    }
}
