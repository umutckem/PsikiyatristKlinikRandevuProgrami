using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Core.Model
{
    public class Recete
    {
        public int Id { get; set; }
        public Guid HastaId { get; set; }
        public Guid PsikiyatristId { get; set; }
        public string IlacBilgileri { get; set; }
        public string TedaviPlani { get; set; }
        public DateTime YazilmaTarihi { get; set; }

    }
}
