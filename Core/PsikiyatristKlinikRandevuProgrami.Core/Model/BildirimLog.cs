using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Core.Model
{
    public class BildirimLog
    {
        public int Id { get; set; }
        public string Mesaj { get; set; }
        public DateTime Tarih { get; set; }
    }
}
