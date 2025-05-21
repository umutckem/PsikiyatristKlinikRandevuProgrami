using MediatR;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Application.GeriBildirim.Commands
{
    public class UpdateGeriBildirimCommand : IRequest<Unit>
    {
        public Core.Model.GeriBildirim GeriBildirim { get; }

        public UpdateGeriBildirimCommand(Core.Model.GeriBildirim geriBildirim)
        {
            GeriBildirim = geriBildirim;
        }
    }
}
