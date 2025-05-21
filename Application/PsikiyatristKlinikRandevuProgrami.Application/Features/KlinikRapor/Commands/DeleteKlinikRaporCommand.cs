using MediatR;

namespace PsikiyatristKlinikRandevuProgrami.Application.Commands.KlinikRapor
{
    public class DeleteKlinikRaporCommand : IRequest<Unit>  // <-- BURASI ÖNEMLİ
    {
        public int KlinikRaporId { get; set; }

        public DeleteKlinikRaporCommand(int klinikRaporId)
        {
            KlinikRaporId = klinikRaporId;
        }
    }
}
