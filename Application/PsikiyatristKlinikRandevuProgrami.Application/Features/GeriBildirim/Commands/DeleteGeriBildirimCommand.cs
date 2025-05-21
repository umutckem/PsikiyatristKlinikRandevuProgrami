using MediatR;

namespace PsikiyatristKlinikRandevuProgrami.Application.GeriBildirim.Commands
{
    public class DeleteGeriBildirimCommand : IRequest<Unit>
    {
        public int GeriBildirimId { get; }

        public DeleteGeriBildirimCommand(int geriBildirimId)
        {
            GeriBildirimId = geriBildirimId;
        }
    }
}
