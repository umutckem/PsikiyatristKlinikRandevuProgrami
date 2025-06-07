using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.DeleteCommand
{
    public class DeleteRandevuCommand : ICommand
    {
        private readonly IRandevuCommandService _commandService;
        private readonly int _randevuId;

        public DeleteRandevuCommand(IRandevuCommandService commandService, int randevuId)
        {
            _commandService = commandService;
            _randevuId = randevuId;
        }

        public void Execute()
        {
            _commandService.DeleteRandevu(_randevuId);
        }
    }
}
