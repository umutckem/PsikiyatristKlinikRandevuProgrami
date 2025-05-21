using MediatR;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Application.Commands.KlinikRapor
{
    public class UpdateKlinikRaporCommand : IRequest<Unit>  // <-- BURASI ÖNEMLİ
    {
        public Core.Model.KlinikRapor KlinikRapor { get; set; }

        public UpdateKlinikRaporCommand(Core.Model.KlinikRapor klinikRapor)
        {
            KlinikRapor = klinikRapor;
        }
    }
}
