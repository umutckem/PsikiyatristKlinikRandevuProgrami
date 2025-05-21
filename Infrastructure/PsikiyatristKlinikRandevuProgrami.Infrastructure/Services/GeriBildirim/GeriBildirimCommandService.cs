using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.GeriBildirim
{
    using PsikiyatristKlinikRandevuProgrami.Core.Model;
    public class GeriBildirimCommandService : IGeriBildirimCommandService
    {
        
        private readonly ApplicationDbContext _context;

        public GeriBildirimCommandService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddGeriBildirim(GeriBildirim geriBildirim)
        {
            _context.geriBildirims.Add(geriBildirim);
            _context.SaveChanges();
        }

        public void UpdateGeriBildirim(GeriBildirim geriBildirim)
        {
            _context.geriBildirims.Update(geriBildirim);
            _context.SaveChanges();
        }

        public void DeleteGeriBildirim(int geriBildirimId)
        {
            var geriBildirim = _context.geriBildirims.Find(geriBildirimId);
            if (geriBildirim != null)
            {
                _context.geriBildirims.Remove(geriBildirim);
                _context.SaveChanges();
            }
        }
    }
}
