using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Core.Model
{
    public class KlinikRapor
    {
        public int Id { get; set; }
        public Guid HastaId { get; set; }
        public Guid PsikiyatristId { get; set; }
        public string RaporIcerigi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
    }
}
