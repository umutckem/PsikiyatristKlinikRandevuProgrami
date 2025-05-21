using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
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
    public class RandevuCommandService : IRandevuCommandService
    {
        private readonly ApplicationDbContext _context;

        public RandevuCommandService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddRandevu(Randevu randevu)
        {
            _context.randevus.Add(randevu);
            _context.SaveChanges();
        }

        public void UpdateRandevu(Randevu randevu)
        {
            _context.randevus.Update(randevu);
            _context.SaveChanges();
        }

        public void DeleteRandevu(int randevuId)
        {
            var randevu = _context.randevus.Find(randevuId);
            if (randevu != null)
            {
                _context.randevus.Remove(randevu);
                _context.SaveChanges();
            }
        }
    }
}
