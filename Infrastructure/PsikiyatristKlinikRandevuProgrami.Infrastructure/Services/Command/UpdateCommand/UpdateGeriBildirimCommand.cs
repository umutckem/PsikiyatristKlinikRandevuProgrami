using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.UpdateCommand
{
    public class UpdateGeriBildirimCommand
    {
        private readonly IGeriBildirimCommandService _commandService;
        private readonly Core.Model.GeriBildirim _geriBildirim;

        public UpdateGeriBildirimCommand(IGeriBildirimCommandService commandService, Core.Model.GeriBildirim geriBildirim)
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
