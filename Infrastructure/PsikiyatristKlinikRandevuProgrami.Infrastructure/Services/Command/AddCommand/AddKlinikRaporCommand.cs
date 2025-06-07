using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.AddCommand
{
    using PsikiyatristKlinikRandevuProgrami.Core.Model;
    public class AddKlinikRaporCommand : ICommand
    {
        private readonly IKlinikRaporCommandService _commandService;
        private readonly KlinikRapor _klinikRapor;

        public AddKlinikRaporCommand(IKlinikRaporCommandService commandService, KlinikRapor klinikRapor)
        {
            _commandService = commandService;
            _klinikRapor = klinikRapor;
        }

        public void Execute()
        {
            _commandService.AddKlinikRapor(_klinikRapor);
        }
    }
}
