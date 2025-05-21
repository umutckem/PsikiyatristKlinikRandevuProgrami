using MediatR;

namespace PsikiyatristKlinikRandevuProgrami.Application.Odeme.Commands
{
    public class DeleteOdemeCommand : IRequest<Unit>
    {
        public int OdemeId { get; }

        public DeleteOdemeCommand(int odemeId)
        {
            OdemeId = odemeId;
        }
    }
}
