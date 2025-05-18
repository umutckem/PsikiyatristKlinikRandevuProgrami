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
    public class BildirimQueryService : IBildirimQueryService
    {
        private readonly ApplicationDbContext _context;

        public BildirimQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Bildirim> GetAllBildirimler()
        {
            return _context.bildirims.ToList();
        }
    }
}
