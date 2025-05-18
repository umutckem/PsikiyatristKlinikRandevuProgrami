using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services
{
    public class UpdateReceteCommand
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
