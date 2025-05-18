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
    public class KullaniciQueryService : IKullaniciQueryService
    {
        private readonly ApplicationDbContext _context;

        public KullaniciQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Kullanici> GetAllKullanicilar()
        {
            return _context.kullanicis.ToList();
        }
    }
}
