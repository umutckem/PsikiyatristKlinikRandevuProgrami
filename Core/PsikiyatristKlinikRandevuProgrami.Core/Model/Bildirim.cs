using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Core.Model
{
    public class Bildirim
    {
        public int Id { get; set; }
        public Guid AliciKullaniciId { get; set; }
        public string Tur { get; set; }
        public string Icerik { get; set; }
        public string GonderimYontemi { get; set; }
        public string Durum { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime? GonderimTarihi { get; set; }
    }
}
