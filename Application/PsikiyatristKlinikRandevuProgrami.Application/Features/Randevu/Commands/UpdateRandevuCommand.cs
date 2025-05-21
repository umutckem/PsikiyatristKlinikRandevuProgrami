using MediatR;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Application.Randevu.Commands
{
    public class UpdateRandevuCommand : IRequest<Unit>
    {
        public Core.Model.Randevu Randevu { get; }

        public UpdateRandevuCommand(Core.Model.Randevu randevu)
        {
            Randevu = randevu;
        }
    }
}
