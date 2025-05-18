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
    public class BildirimCommandService : IBildirimCommandService
    {
        private readonly ApplicationDbContext _context;

        public BildirimCommandService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBildirim(Bildirim bildirim)
        {
            _context.bildirims.Add(bildirim);
            _context.SaveChanges();
        }

        public void UpdateBildirim(Bildirim bildirim)
        {
            _context.bildirims.Update(bildirim);
            _context.SaveChanges();
        }

        public void DeleteBildirim(int bildirimId)
        {
            var entity = _context.bildirims.Find(bildirimId);
            if (entity != null)
            {
                _context.bildirims.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
