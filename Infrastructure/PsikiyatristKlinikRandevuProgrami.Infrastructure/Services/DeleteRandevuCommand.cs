using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services
{
    public class DeleteRandevuCommand
    {
        private readonly IRandevuCommandService _commandService;
        private readonly int _randevuId;

        public DeleteRandevuCommand(IRandevuCommandService commandService, int randevuId)
        {
            _commandService = commandService;
            _randevuId = randevuId;
        }

        public void Execute()
        {
            _commandService.DeleteRandevu(_randevuId);
        }
    }
}
