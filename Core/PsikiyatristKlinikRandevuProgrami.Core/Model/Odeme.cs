using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Core.Model
{
    public class Odeme
    {
        public int Id { get; set; }
        public Guid HastaId { get; set; }
        public decimal Ucret { get; set; }
        public DateTime OdemeTarihi { get; set; }
        public string OdemeYontemi { get; set; }
        public string Aciklama { get; set; }
    }
}
