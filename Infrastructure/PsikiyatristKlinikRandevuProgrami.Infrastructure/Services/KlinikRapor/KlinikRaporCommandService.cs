using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
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
    public class KlinikRaporCommandService : IKlinikRaporCommandService
    {
        private readonly ApplicationDbContext _context;

        public KlinikRaporCommandService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddKlinikRapor(KlinikRapor klinikRapor)
        {
            _context.klinikRapors.Add(klinikRapor);
            _context.SaveChanges();
        }

        public void UpdateKlinikRapor(KlinikRapor klinikRapor)
        {
            _context.klinikRapors.Update(klinikRapor);
            _context.SaveChanges();
        }

        public void DeleteKlinikRapor(int klinikRaporId)
        {
            var rapor = _context.klinikRapors.Find(klinikRaporId);
            if (rapor != null)
            {
                _context.klinikRapors.Remove(rapor);
                _context.SaveChanges();
            }
        }
    }
}
