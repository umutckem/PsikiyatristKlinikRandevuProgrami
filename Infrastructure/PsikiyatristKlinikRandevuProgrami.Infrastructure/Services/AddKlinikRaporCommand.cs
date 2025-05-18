using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services
{
    public class AddKlinikRaporCommand
    {
        private readonly IKlinikRaporCommandService _commandService;
        private readonly KlinikRapor _klinikRapor;

        public AddKlinikRaporCommand(IKlinikRaporCommandService commandService, KlinikRapor klinikRapor)
        {
            _commandService = commandService;
            _klinikRapor = klinikRapor;
        }

        public void Execute()
        {
            _commandService.AddKlinikRapor(_klinikRapor);
        }
    }
}
