using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Features.Bildirim.Query;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using System.Security.Claims;
using System.Threading.Tasks;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services; // Observer sınıfları buradaysa

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Doktor.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = "Doktor")]
    public class BildirimlerController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;

        public BildirimlerController(IMediator mediator, ApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userIdStr, out var psikiyatristId))
                return Unauthorized();

            var bildirimler = await _mediator.Send(new GetAllBildirimlerQuery());
            var doktorBildirimleri = bildirimler
                .Where(b => b.AliciKullaniciId == psikiyatristId)
                .ToList();

            return View(doktorBildirimleri);
        }

        [HttpPost]
        public IActionResult YeniBildirimGonder(Guid aliciId, string icerik)
        {
            var bildirim = new Bildirim
            {
                AliciKullaniciId = aliciId,
                Icerik = icerik,
                GonderimYontemi = "Sistemİçi",
                Tur = "Genel"
            };

            // Observer kurulum
            var subject = new Subject();
            var dbObserver = new BildirimObserver(_context);
            subject.Attach(dbObserver);

            subject.Notify(bildirim); // Bildirim veritabanına işlenir

            TempData["Message"] = "Bildirim başarıyla gönderildi.";
            return RedirectToAction("Index");
        }
    }
}
