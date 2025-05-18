using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services
{
    public class UpdateOdemeCommand
    {
        private readonly IOdemeCommandService _commandService;
        private readonly Odeme _odeme;

        public UpdateOdemeCommand(IOdemeCommandService commandService, Odeme odeme)
        {
            _commandService = commandService;
            _odeme = odeme;
        }

        public void Execute()
        {
            _commandService.UpdateOdeme(_odeme);
        }
    }
}
