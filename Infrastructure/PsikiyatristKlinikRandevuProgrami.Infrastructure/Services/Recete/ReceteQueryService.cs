using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Recete
{
    public class ReceteQueryService : IReceteQueryService
    {
        private readonly ApplicationDbContext _context;

        public ReceteQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Core.Model.Recete> GetAllReceteler()
        {
            return _context.recetes.ToList();
        }
    }
}
