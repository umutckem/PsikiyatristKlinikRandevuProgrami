using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.AddCommand
{
    using PsikiyatristKlinikRandevuProgrami.Core.Model;
    public class AddReceteCommand : ICommand
    {
        private readonly IReceteCommandService _commandService;
        private readonly Recete _recete;

        public AddReceteCommand(IReceteCommandService commandService, Recete recete)
        {
            _commandService = commandService;
            _recete = recete;
        }

        public void Execute()
        {
            _commandService.AddRecete(_recete);
        }
    }
}
