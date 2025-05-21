using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.AddCommand
{
    public class AddRandevuCommand : ICommand
    {
        private readonly IRandevuCommandService _commandService;
        private readonly Core.Model.Randevu _randevu;

        public AddRandevuCommand(IRandevuCommandService commandService, Core.Model.Randevu randevu)
        {
            _commandService = commandService;
            _randevu = randevu;
        }

        public void Execute()
        {
            _commandService.AddRandevu(_randevu);
        }
    }
}
