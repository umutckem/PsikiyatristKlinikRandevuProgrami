using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.DeleteCommand
{
    public class DeleteReceteCommand : ICommand
    {
        private readonly IReceteCommandService _commandService;
        private readonly int _receteId;

        public DeleteReceteCommand(IReceteCommandService commandService, int receteId)
        {
            _commandService = commandService;
            _receteId = receteId;
        }

        public void Execute()
        {
            _commandService.DeleteRecete(_receteId);
        }
    }
}
