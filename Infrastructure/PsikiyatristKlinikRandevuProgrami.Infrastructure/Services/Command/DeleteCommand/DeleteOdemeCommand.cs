using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.DeleteCommand
{
    public class DeleteOdemeCommand
    {
        private readonly IOdemeCommandService _commandService;
        private readonly int _odemeId;

        public DeleteOdemeCommand(IOdemeCommandService commandService, int odemeId)
        {
            _commandService = commandService;
            _odemeId = odemeId;
        }

        public void Execute()
        {
            _commandService.DeleteOdeme(_odemeId);
        }
    }
}
