using MediatR;

namespace PsikiyatristKlinikRandevuProgrami.Application.Kullanici.Commands
{
    public class DeleteKullaniciCommand : IRequest<Unit>
    {
        public int KullaniciId { get; }

        public DeleteKullaniciCommand(int kullaniciId)
        {
            KullaniciId = kullaniciId;
        }
    }
}
