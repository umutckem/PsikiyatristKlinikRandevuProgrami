using Microsoft.EntityFrameworkCore;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Kullanici
{
    using PsikiyatristKlinikRandevuProgrami.Core.Model;
    public class KullaniciQueryService : IKullaniciQueryService
    {
        private readonly ApplicationDbContext _context;

        public KullaniciQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        Task<List<Kullanici>> IKullaniciQueryService.GetAllKullanicilar()
        {
            return _context.kullanicis.ToListAsync();
        }
    }
}
