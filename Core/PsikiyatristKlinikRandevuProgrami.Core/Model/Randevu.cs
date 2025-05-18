using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Core.Model
{
    public class Randevu
    {
        public int Id { get; set; }
        public Guid HastaId { get; set; }
        public Guid PsikiyatristId { get; set; }
        public DateTime TarihSaat { get; set; }
        public string Durum { get; set; }
        public string Aciklama { get; set; }
    }
}
