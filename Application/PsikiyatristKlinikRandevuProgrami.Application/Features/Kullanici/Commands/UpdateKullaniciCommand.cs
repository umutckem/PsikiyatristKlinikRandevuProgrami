using MediatR;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgrami.Application.Kullanici.Commands
{
    public class UpdateKullaniciCommand : IRequest<Unit>
    {
        public Core.Model.Kullanici Kullanici { get; }

        public UpdateKullaniciCommand(Core.Model.Kullanici kullanici)
        {
            Kullanici = kullanici;
        }
    }
}
