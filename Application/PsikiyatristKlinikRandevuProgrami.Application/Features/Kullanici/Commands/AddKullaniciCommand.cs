using MediatR;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Application.Kullanici.Commands
{
    public class AddKullaniciCommand : IRequest<Unit>
    {
        public Core.Model.Kullanici Kullanici { get; }

        public AddKullaniciCommand(Core.Model.Kullanici kullanici)
        {
            Kullanici = kullanici;
        }
    }
}
