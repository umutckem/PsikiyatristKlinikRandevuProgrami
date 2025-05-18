using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services
{
    public class DeleteKlinikRaporCommand
    {
        private readonly IKlinikRaporCommandService _commandService;
        private readonly int _klinikRaporId;

        public DeleteKlinikRaporCommand(IKlinikRaporCommandService commandService, int klinikRaporId)
        {
            _commandService = commandService;
            _klinikRaporId = klinikRaporId;
        }

        public void Execute()
        {
            _commandService.DeleteKlinikRapor(_klinikRaporId);
        }
    }
}
