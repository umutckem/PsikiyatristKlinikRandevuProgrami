using MediatR;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Application.KlinikRapor.Commands
{
    // IRequest<Unit> döndürmeli!
    public class AddKlinikRaporCommand : IRequest<Unit>
    {
        public Core.Model.KlinikRapor KlinikRapor { get; }

        public AddKlinikRaporCommand(Core.Model.KlinikRapor klinikRapor)
        {
            KlinikRapor = klinikRapor;
        }
    }
}
