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
    public class BildirimObserver : IObserver
    {
        private readonly ApplicationDbContext _context;

        public BildirimObserver(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Update(Bildirim bildirim)
        {
            bildirim.OlusturmaTarihi = DateTime.Now;
            bildirim.Durum = "Bekliyor";
            bildirim.GonderimTarihi = null;

            _context.bildirims.Add(bildirim);
            _context.SaveChanges();
        }
    }
}
