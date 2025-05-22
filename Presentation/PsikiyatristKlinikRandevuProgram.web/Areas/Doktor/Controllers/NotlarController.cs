using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.KlinikRapor.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Kullanici.Queries;
using PsikiyatristKlinikRandevuProgrami.Application.Randevu.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using System.Security.Claims;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Doktor.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = "Doktor")]
    public class NotlarController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;

        public NotlarController(IMediator mediator, ApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userIdStr, out var psikiyatristId))
                return Unauthorized();

            var tumRandevular = await _mediator.Send(new GetAllRandevularQuery());

            var kendiRandevulari = tumRandevular
                .Where(r => r.PsikiyatristId == psikiyatristId)
                .OrderBy(r => r.TarihSaat)
                .ToList();

            return View(kendiRandevulari);
        }

        [HttpGet]
        public IActionResult RaporEkle(int randevuId)
        {
            return View(new KlinikRapor
            {
                OlusturmaTarihi = DateTime.Now,
                // bu değerler formda saklanacak
                Id = randevuId
            });
        }

        [HttpPost]
        public async Task<IActionResult> RaporEkle(KlinikRapor rapor)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userIdStr, out var psikiyatristId))
                return Unauthorized();

            rapor.PsikiyatristId = psikiyatristId;
            rapor.OlusturmaTarihi = DateTime.Now;

            await _mediator.Send(new AddKlinikRaporCommand(rapor));

            return RedirectToAction("Index");
        }




    }
}
