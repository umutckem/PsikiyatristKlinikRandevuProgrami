using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Randevu
{
    public class RandevuQueryService : IRandevuQueryService
    {
        private readonly ApplicationDbContext _context;

        public RandevuQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Core.Model.Randevu> GetAllRandevular()
        {
            return _context.randevus.ToList();
        }

        public List<Core.Model.Randevu> GetRandevularByPsikiyatristId(Guid psikiyatristId)
        {
            return _context.randevus
                .Where(r => r.PsikiyatristId == psikiyatristId)
                .ToList();
        }
    }
}
