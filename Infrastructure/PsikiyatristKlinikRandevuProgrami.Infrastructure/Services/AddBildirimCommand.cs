using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services
{
    public class AddBildirimCommand
    {
        private readonly IBildirimCommandService _commandService;
        private readonly Bildirim _bildirim;

        public AddBildirimCommand(IBildirimCommandService commandService, Bildirim bildirim)
        {
            _commandService = commandService;
            _bildirim = bildirim;
        }

        public void Execute()
        {
            _commandService.AddBildirim(_bildirim);
        }
    }
}
