using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.DeleteCommand
{
    public class DeleteGeriBildirimCommand : ICommand
    {
        private readonly IGeriBildirimCommandService _commandService;
        private readonly int _geriBildirimId;

        public DeleteGeriBildirimCommand(IGeriBildirimCommandService commandService, int geriBildirimId)
        {
            _commandService = commandService;
            _geriBildirimId = geriBildirimId;
        }

        public void Execute()
        {
            _commandService.DeleteGeriBildirim(_geriBildirimId);
        }
    }
}
