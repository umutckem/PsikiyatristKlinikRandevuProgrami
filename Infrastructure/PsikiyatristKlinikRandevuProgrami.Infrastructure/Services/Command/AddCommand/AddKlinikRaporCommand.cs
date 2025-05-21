using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.AddCommand
{
    public class AddKlinikRaporCommand
    {
        private readonly IKlinikRaporCommandService _commandService;
        private readonly Core.Model.KlinikRapor _klinikRapor;

        public AddKlinikRaporCommand(IKlinikRaporCommandService commandService, Core.Model.KlinikRapor klinikRapor)
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
