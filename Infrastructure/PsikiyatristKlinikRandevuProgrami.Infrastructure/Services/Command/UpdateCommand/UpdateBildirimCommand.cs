using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.UpdateCommand
{
    using PsikiyatristKlinikRandevuProgrami.Core.Model;
    public class UpdateBildirimCommand : ICommand
    {
        private readonly IBildirimCommandService _commandService;
        private readonly Bildirim _bildirim;

        public UpdateBildirimCommand(IBildirimCommandService commandService, Bildirim bildirim)
        {
            _commandService = commandService;
            _bildirim = bildirim;
        }

        public void Execute()
        {
            _commandService.UpdateBildirim(_bildirim);
        }
    }
}
