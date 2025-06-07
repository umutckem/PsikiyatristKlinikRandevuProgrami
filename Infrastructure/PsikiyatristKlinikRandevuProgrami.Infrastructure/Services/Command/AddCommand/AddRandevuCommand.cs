using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.AddCommand
{
    using PsikiyatristKlinikRandevuProgrami.Core.Model;
    public class AddRandevuCommand : ICommand
    {
        private readonly IRandevuCommandService _commandService;
        private readonly Randevu _randevu;

        public AddRandevuCommand(IRandevuCommandService commandService, Randevu randevu)
        {
            _commandService = commandService;
            _randevu = randevu;
        }

        public void Execute()
        {
            _commandService.AddRandevu(_randevu);
        }
    }
}
