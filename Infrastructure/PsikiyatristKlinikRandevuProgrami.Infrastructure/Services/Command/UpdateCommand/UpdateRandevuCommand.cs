using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.UpdateCommand
{
    using PsikiyatristKlinikRandevuProgrami.Core.Model;
    public class UpdateRandevuCommand : ICommand
    {
        private readonly IRandevuCommandService _commandService;
        private readonly Randevu _randevu;

        public UpdateRandevuCommand(IRandevuCommandService commandService, Randevu randevu)
        {
            _commandService = commandService;
            _randevu = randevu;
        }

        public void Execute()
        {
            _commandService.UpdateRandevu(_randevu);
        }
    }
}
