using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.AddCommand
{
    using PsikiyatristKlinikRandevuProgrami.Core.Model;
    public class AddGeriBildirimCommand
    {
        private readonly IGeriBildirimCommandService _commandService;
        private readonly GeriBildirim _geriBildirim;

        public AddGeriBildirimCommand(IGeriBildirimCommandService commandService, GeriBildirim geriBildirim)
        {
            _commandService = commandService;
            _geriBildirim = geriBildirim;
        }

        public void Execute()
        {
            _commandService.AddGeriBildirim(_geriBildirim);
        }
    }
}
