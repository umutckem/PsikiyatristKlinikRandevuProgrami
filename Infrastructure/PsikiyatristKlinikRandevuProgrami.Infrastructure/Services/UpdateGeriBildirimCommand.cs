using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services
{
    public class UpdateGeriBildirimCommand
    {
        private readonly IGeriBildirimCommandService _commandService;
        private readonly GeriBildirim _geriBildirim;

        public UpdateGeriBildirimCommand(IGeriBildirimCommandService commandService, GeriBildirim geriBildirim)
        {
            _commandService = commandService;
            _geriBildirim = geriBildirim;
        }

        public void Execute()
        {
            _commandService.UpdateGeriBildirim(_geriBildirim);
        }
    }
}
