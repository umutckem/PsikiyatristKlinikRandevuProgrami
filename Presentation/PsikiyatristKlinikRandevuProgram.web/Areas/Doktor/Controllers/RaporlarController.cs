using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Application.KlinikRapor.Queries;
using PsikiyatristKlinikRandevuProgrami.Application.Kullanici.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Doktor.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = "Doktor")]
    public class RaporlarController : Controller
    {
        private readonly IKlinikRaporQueryService _klinikRaporQueryService;
        private readonly IKlinikRaporCommandService _klinikRaporCommandService;
        private readonly IMediator _mediator;

        public RaporlarController(IMediator mediator, IKlinikRaporQueryService klinikRaporQueryService, IKlinikRaporCommandService klinikRaporCommandService)
        {
            _mediator = mediator;
            _klinikRaporQueryService = klinikRaporQueryService;
            _klinikRaporCommandService = klinikRaporCommandService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                TempData["ErrorMessage"] = "Kullanıcı kimliği bulunamadı. Lütfen tekrar giriş yapınız.";
                return RedirectToAction("Login", "Account", new { area = "" });
            }

            var kullaniciBilgileri = await _mediator.Send(new GetAllKullanicilarQuery());
            var doktorBilgileri = kullaniciBilgileri.FirstOrDefault(x => x.IdentityUserId == userId);

            if (doktorBilgileri == null)
            {
                TempData["ErrorMessage"] = "Doktor bilgileri bulunamadı.";
                return RedirectToAction("Login", "Account", new { area = "" });
            }

            var randevular = await _mediator.Send(new GetAllKlinikRaporlarQuery());
            var doktorRandevular = randevular
                .Where(x => x.PsikiyatristId == Guid.Parse(doktorBilgileri.IdentityUserId))
                .ToList();

            ViewBag.DoktorAdiSoyadi = doktorBilgileri.Ad + " " + doktorBilgileri.Soyad;

            var doktorKullanicibilgileri = kullaniciBilgileri
            .Where(x => doktorRandevular.Any(r => r.HastaId == Guid.Parse(x.IdentityUserId)))
            .ToList();


            ViewBag.Randevular = doktorKullanicibilgileri;

            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var raporlar = _klinikRaporQueryService.GetAllKlinikRaporlar()
                            .Where(x => x.HastaId == id)
                            .ToList();

            if (raporlar == null || !raporlar.Any())
                return NotFound();

            return View(raporlar);
        }
    }
}
