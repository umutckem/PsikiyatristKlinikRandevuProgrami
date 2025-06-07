using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.AddCommand
{
    using PsikiyatristKlinikRandevuProgrami.Core.Model;
    public class AddBildirimCommand : ICommand
    {

        private readonly IBildirimCommandService _commandService;
        private readonly Bildirim _bildirim;

        public AddBildirimCommand(IBildirimCommandService commandService, Bildirim bildirim)
        {
            _commandService = commandService;
            _bildirim = bildirim;
        }

        public void Execute()
        {
            _commandService.AddBildirim(_bildirim);
        }
    }
}
