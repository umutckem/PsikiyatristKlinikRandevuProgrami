using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services
{
    public class DeleteReceteCommand
    {
        private readonly IReceteCommandService _commandService;
        private readonly int _receteId;

        public DeleteReceteCommand(IReceteCommandService commandService, int receteId)
        {
            _commandService = commandService;
            _receteId = receteId;
        }

        public void Execute()
        {
            _commandService.DeleteRecete(_receteId);
        }
    }
}
