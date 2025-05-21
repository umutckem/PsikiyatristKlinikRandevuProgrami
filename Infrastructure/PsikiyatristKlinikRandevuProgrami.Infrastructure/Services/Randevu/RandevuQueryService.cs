using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Randevu
{
    using PsikiyatristKlinikRandevuProgrami.Core.Model;
    public class RandevuQueryService : IRandevuQueryService
    {
        private readonly ApplicationDbContext _context;

        public RandevuQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Randevu> GetAllRandevular()
        {
            return _context.randevus.ToList();
        }
    }
}
