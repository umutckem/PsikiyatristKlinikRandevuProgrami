using MediatR;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Application.GeriBildirim.Commands
{
    public class AddGeriBildirimCommand : IRequest<Unit>
    {
        public Core.Model.GeriBildirim GeriBildirim { get; set; }

        public AddGeriBildirimCommand(Core.Model.GeriBildirim geriBildirim)
        {
            GeriBildirim = geriBildirim;
        }
    }
}
