using MediatR;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Application.Randevu.Commands
{
    public class AddRandevuCommand : IRequest<Unit>
    {
        public Core.Model.Randevu Randevu { get; }

        public AddRandevuCommand(Core.Model.Randevu randevu)
        {
            Randevu = randevu;
        }
    }
}
