using MediatR;

namespace PsikiyatristKlinikRandevuProgrami.Application.Randevu.Commands
{
    public class DeleteRandevuCommand : IRequest<Unit>
    {
        public int RandevuId { get; }

        public DeleteRandevuCommand(int randevuId)
        {
            RandevuId = randevuId;
        }
    }
}
