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
    public class GeriBildirimQueryService : IGeriBildirimQueryService
    {
        private readonly ApplicationDbContext _context;

        public GeriBildirimQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<GeriBildirim> GetAllGeriBildirims()
        {
            return _context.geriBildirims.ToList();
        }
    }
}
