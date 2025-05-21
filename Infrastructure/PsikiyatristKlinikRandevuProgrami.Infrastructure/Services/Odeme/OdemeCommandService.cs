using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Odeme
{
    using PsikiyatristKlinikRandevuProgrami.Core.Model;
    public class OdemeCommandService : IOdemeCommandService
    {
        private readonly ApplicationDbContext _context;

        public OdemeCommandService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddOdeme(Odeme odeme)
        {
            _context.odemes.Add(odeme);
            _context.SaveChanges();
        }

        public void UpdateOdeme(Odeme odeme)
        {
            _context.odemes.Update(odeme);
            _context.SaveChanges();
        }

        public void DeleteOdeme(int odemeId)
        {
            var odeme = _context.odemes.Find(odemeId);
            if (odeme != null)
            {
                _context.odemes.Remove(odeme);
                _context.SaveChanges();
            }
        }
    }
}
