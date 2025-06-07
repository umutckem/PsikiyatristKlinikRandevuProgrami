using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.AddCommand
{

    using PsikiyatristKlinikRandevuProgrami.Core.Model;
    public class AddOdemeCommand : ICommand
    {
        private readonly IOdemeCommandService _commandService;
        private readonly Odeme _odeme;

        public AddOdemeCommand(IOdemeCommandService commandService, Odeme odeme)
        {
            _commandService = commandService;
            _odeme = odeme;
        }

        public void Execute()
        {
            _commandService.AddOdeme(_odeme);
        }
    }
}
