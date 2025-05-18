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
    public class BildirimLogObserver : IObserver
    {
        private readonly ApplicationDbContext _context;

        public BildirimLogObserver(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Update(string message)
        {
            var log = new BildirimLog
            {
                Mesaj = message,
                Tarih = DateTime.Now
            };

            _context.bildirimLogs.Add(log);
            _context.SaveChanges();
        }
    }
}
