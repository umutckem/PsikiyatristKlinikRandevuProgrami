using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.UpdateCommand
{
    using PsikiyatristKlinikRandevuProgrami.Core.Model;
    public class UpdateKlinikRaporCommand : ICommand
    {
        private readonly IKlinikRaporCommandService _commandService;
        private readonly KlinikRapor _klinikRapor;

        public UpdateKlinikRaporCommand(IKlinikRaporCommandService commandService, KlinikRapor klinikRapor)
        {
            _commandService = commandService;
            _klinikRapor = klinikRapor;
        }

        public void Execute()
        {
            _commandService.UpdateKlinikRapor(_klinikRapor);
        }
    }
}
