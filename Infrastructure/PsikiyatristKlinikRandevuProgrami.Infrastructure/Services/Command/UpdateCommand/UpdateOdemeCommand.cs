using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.UpdateCommand
{
    using PsikiyatristKlinikRandevuProgrami.Core.Model;
    public class UpdateOdemeCommand : ICommand
    {
        private readonly IOdemeCommandService _commandService;
        private readonly Odeme _odeme;

        public UpdateOdemeCommand(IOdemeCommandService commandService, Odeme odeme)
        {
            _commandService = commandService;
            _odeme = odeme;
        }

        public void Execute()
        {
            _commandService.UpdateOdeme(_odeme);
        }
    }
}
