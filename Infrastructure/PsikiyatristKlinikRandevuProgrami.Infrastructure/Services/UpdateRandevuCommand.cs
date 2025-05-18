using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services
{
    public class UpdateRandevuCommand
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
