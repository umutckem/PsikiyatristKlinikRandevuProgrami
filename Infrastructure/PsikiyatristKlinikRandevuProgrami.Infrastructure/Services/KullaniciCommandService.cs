using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services
{
    public class KullaniciCommandService : IKullaniciCommandService
    {
        private readonly ApplicationDbContext _context;

        public KullaniciCommandService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddKullanici(Kullanici kullanici)
        {
            _context.kullanicis.Add(kullanici);
            _context.SaveChanges();
        }

        public void UpdateKullanici(Kullanici kullanici)
        {
            _context.kullanicis.Update(kullanici);
            _context.SaveChanges();
        }

        public void DeleteKullanici(int kullaniciId)
        {
            var kullanici = _context.kullanicis.Find(kullaniciId);
            if (kullanici != null)
            {
                _context.kullanicis.Remove(kullanici);
                _context.SaveChanges();
            }
        }
    }
}
