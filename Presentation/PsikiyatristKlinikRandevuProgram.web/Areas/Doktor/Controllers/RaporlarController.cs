using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMediator _mediator;

        public RaporlarController(IMediator mediator, IKlinikRaporQueryService klinikRaporQueryService)
        {
            _mediator = mediator;
            _klinikRaporQueryService = klinikRaporQueryService;
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
            ViewBag.Randevular = doktorRandevular;

            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var raporlar = _klinikRaporQueryService.GetAllKlinikRaporlar();
            var rapor = raporlar.FirstOrDefault(x => x.Id == id);
            if (rapor == null)
                return NotFound();

            var viewModel = new KlinikRapor
            {
                Id = rapor.Id,
                HastaId = rapor.HastaId,
                PsikiyatristId = rapor.PsikiyatristId,
                RaporIcerigi = rapor.RaporIcerigi,
                OlusturmaTarihi = rapor.OlusturmaTarihi
            };

            return View(viewModel);
        }


    }
}
