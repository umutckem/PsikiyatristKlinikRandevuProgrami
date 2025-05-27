using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.KlinikRapor.Queries;
using PsikiyatristKlinikRandevuProgrami.Application.Kullanici.Queries;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Doktor.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = "Doktor")]
    public class RaporlarController : Controller
    {
        private readonly IMediator _mediator;

        public RaporlarController(IMediator mediator)
        {
            _mediator = mediator;
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


    }
}
