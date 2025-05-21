using MediatR;

namespace PsikiyatristKlinikRandevuProgrami.Application.Recete.Commands
{
    public class DeleteReceteCommand : IRequest<Unit>
    {
        public int ReceteId { get; }

        public DeleteReceteCommand(int receteId)
        {
            ReceteId = receteId;
        }
    }
}
