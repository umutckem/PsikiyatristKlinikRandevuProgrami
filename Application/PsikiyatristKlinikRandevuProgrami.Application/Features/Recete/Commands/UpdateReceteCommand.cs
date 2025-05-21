using MediatR;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Application.Recete.Commands
{
    public class UpdateReceteCommand : IRequest<Unit>
    {
        public Core.Model.Recete Recete { get; }

        public UpdateReceteCommand(Core.Model.Recete recete)
        {
            Recete = recete;
        }
    }
}
