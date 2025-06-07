using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.UpdateCommand
{
    using PsikiyatristKlinikRandevuProgrami.Core.Model;
    public class UpdateReceteCommand : ICommand
    {
        private readonly IReceteCommandService _commandService;
        private readonly Recete _recete;

        public UpdateReceteCommand(IReceteCommandService commandService, Recete recete)
        {
            _commandService = commandService;
            _recete = recete;
        }

        public void Execute()
        {
            _commandService.UpdateRecete(_recete);
        }
    }
}
