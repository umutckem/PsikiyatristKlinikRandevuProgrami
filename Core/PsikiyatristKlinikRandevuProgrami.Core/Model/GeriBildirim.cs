using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Core.Model
{
    public class GeriBildirim
    {
        public int Id { get; set; }
        public Guid KullaniciId { get; set; }
        public string Tur { get; set; }
        public string Aciklama { get; set; }
        public int? Puan { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public string Kategori { get; set; }
    }
}
