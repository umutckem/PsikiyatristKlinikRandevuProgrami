using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.AddCommand
{
    public class AddGeriBildirimCommand
    {
        private readonly IGeriBildirimCommandService _commandService;
        private readonly Core.Model.GeriBildirim _geriBildirim;

        public AddGeriBildirimCommand(IGeriBildirimCommandService commandService, Core.Model.GeriBildirim geriBildirim)
        {
            _commandService = commandService;
            _geriBildirim = geriBildirim;
        }

        public void Execute()
        {
            _commandService.AddGeriBildirim(_geriBildirim);
        }
    }
}
