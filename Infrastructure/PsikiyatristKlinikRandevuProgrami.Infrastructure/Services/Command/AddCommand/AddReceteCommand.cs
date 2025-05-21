using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.AddCommand
{
    public class AddReceteCommand
    {
        private readonly IReceteCommandService _commandService;
        private readonly Core.Model.Recete _recete;

        public AddReceteCommand(IReceteCommandService commandService, Core.Model.Recete recete)
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
