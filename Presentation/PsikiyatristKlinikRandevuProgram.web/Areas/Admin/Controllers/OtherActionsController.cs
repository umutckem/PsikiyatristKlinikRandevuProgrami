using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OtherActionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OtherActionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(); // Sadece buton var
        }

        public async Task<IActionResult> Sikayetler()
        {
            var sikayetler = await _context.geriBildirims
                .Where(g => g.Tur == "Şikayet")
                .OrderByDescending(g => g.OlusturmaTarihi)
                .ToListAsync();

            return View(sikayetler);
        }
    }
}
