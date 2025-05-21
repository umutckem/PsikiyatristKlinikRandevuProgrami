using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.KlinikRapor
{
    using PsikiyatristKlinikRandevuProgrami.Core.Model;
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
