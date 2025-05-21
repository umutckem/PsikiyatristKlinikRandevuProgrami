using MediatR;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Application.Recete.Commands
{
    public class AddReceteCommand : IRequest<Unit>
    {
        public Core.Model.Recete Recete { get; }

        public AddReceteCommand(Core.Model.Recete recete)
        {
            Recete = recete;
        }
    }
}
