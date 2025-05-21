using MediatR;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Application.Odeme.Commands
{
    public class AddOdemeCommand : IRequest<Unit>
    {
        public Core.Model.Odeme Odeme { get; }

        public AddOdemeCommand(Core.Model.Odeme odeme)
        {
            Odeme = odeme;
        }
    }
}
