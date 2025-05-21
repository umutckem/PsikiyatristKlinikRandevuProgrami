using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Kullanici
{
    using PsikiyatristKlinikRandevuProgrami.Core.Model;

    public class KullaniciCommandService : IKullaniciCommandService
    {

        private readonly ApplicationDbContext _context;

        public KullaniciCommandService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddKullanici(Kullanici kullanici)
        {
            _context.kullanicis.Add(kullanici);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateKullanici(Kullanici kullanici)
        {
            _context.kullanicis.Update(kullanici);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteKullanici(int kullaniciId)
        {
            var kullanici = await _context.kullanicis.FindAsync(kullaniciId);
            if (kullanici != null)
            {
                _context.kullanicis.Remove(kullanici);
                await _context.SaveChangesAsync();
            }
        }
    }
}
