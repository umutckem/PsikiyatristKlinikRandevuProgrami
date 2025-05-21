using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.DeleteCommand
{
    public class DeleteBildirimCommand
    {
        private readonly IBildirimCommandService _commandService;
        private readonly int _bildirimId;

        public DeleteBildirimCommand(IBildirimCommandService commandService, int bildirimId)
        {
            _commandService = commandService;
            _bildirimId = bildirimId;
        }

        public void Execute()
        {
            _commandService.DeleteBildirim(_bildirimId);
        }
    }
}
