using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.UpdateCommand
{

    using PsikiyatristKlinikRandevuProgrami.Core.Model;
    public class UpdateGeriBildirimCommand : ICommand
    {
        private readonly IGeriBildirimCommandService _commandService;
        private readonly GeriBildirim _geriBildirim;

        public UpdateGeriBildirimCommand(IGeriBildirimCommandService commandService, GeriBildirim geriBildirim)
        {
            _commandService = commandService;
            _geriBildirim = geriBildirim;
        }

        public void Execute()
        {
            _commandService.UpdateGeriBildirim(_geriBildirim);
        }
    }
}
