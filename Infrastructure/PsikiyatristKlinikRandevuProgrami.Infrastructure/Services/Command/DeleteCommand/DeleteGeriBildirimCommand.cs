using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.DeleteCommand
{
    public class DeleteGeriBildirimCommand
    {
        private readonly IGeriBildirimCommandService _commandService;
        private readonly int _geriBildirimId;

        public DeleteGeriBildirimCommand(IGeriBildirimCommandService commandService, int geriBildirimId)
        {
            _commandService = commandService;
            _geriBildirimId = geriBildirimId;
        }

        public void Execute()
        {
            _commandService.DeleteGeriBildirim(_geriBildirimId);
        }
    }
}
