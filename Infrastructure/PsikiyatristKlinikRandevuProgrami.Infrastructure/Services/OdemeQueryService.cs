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
    public class OdemeQueryService : IOdemeQueryService
    {
        private readonly ApplicationDbContext _context;

        public OdemeQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Odeme> GetAllOdemeler()
        {
            return _context.odemes.ToList();
        }
    }
}
