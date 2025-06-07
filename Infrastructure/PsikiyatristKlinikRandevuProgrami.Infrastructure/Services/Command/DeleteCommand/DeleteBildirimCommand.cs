using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.DeleteCommand
{
    public class DeleteBildirimCommand : ICommand
    {
        private readonly IBildirimCommandService _commandService;
        private readonly int _bildirimId;

        public DeleteBildirimCommand(IBildirimCommandService commandService, int bildirimId)
        {
            _commandService = commandService;
            _bildirimId = bildirimId;
        }

        public void Execute()
        {
            _commandService.DeleteBildirim(_bildirimId);
        }
    }
}
