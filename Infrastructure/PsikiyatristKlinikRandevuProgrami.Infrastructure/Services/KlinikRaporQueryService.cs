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
    public class KlinikRaporQueryService : IKlinikRaporQueryService
    {
        private readonly ApplicationDbContext _context;

        public KlinikRaporQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<KlinikRapor> GetAllKlinikRaporlar()
        {
            return _context.klinikRapors.ToList();
        }
    }
}
