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
    public class ReceteCommandService : IReceteCommandService
    {
        private readonly ApplicationDbContext _context;

        public ReceteCommandService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddRecete(Recete recete)
        {
            _context.recetes.Add(recete);
            _context.SaveChanges();
        }

        public void UpdateRecete(Recete recete)
        {
            _context.recetes.Update(recete);
            _context.SaveChanges();
        }

        public void DeleteRecete(int receteId)
        {
            var recete = _context.recetes.Find(receteId);
            if (recete != null)
            {
                _context.recetes.Remove(recete);
                _context.SaveChanges();
            }
        }
    }
}
