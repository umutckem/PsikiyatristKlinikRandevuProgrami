using MediatR;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Application.Odeme.Commands
{
    public class UpdateOdemeCommand : IRequest<Unit>
    {
        public Core.Model.Odeme Odeme { get; }

        public UpdateOdemeCommand(Core.Model.Odeme odeme)
        {
            Odeme = odeme;
        }
    }
}
