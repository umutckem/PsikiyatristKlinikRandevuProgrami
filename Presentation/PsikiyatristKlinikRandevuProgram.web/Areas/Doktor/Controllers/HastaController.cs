using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsikiyatristKlinikRandevuProgrami.Application.Kullanici.Queries;
using PsikiyatristKlinikRandevuProgrami.Application.Randevu.Queries;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Doktor.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = "Doktor")]
    public class HastaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;

        public HastaController(IMediator mediator , ApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // 1. Tüm kullanıcıları al
            var tumKullanicilar = await _mediator.Send(new GetAllKullanicilarQuery());

            // 2. Identity'deki roller ve kullanıcılar
            var identityRoller = _context.Roles.ToList();
            var identityKullanicilar = _context.Users.ToList();

            var hastaRolu = identityRoller.FirstOrDefault(x => x.Name == "Hasta");
            if (hastaRolu == null)
            {
                TempData["ErrorMessage"] = "Hasta rolü bulunamadı.";
                return RedirectToAction("Index", "Home");
            }

            // 3. Identity'de gerçekten kayıtlı olan kullanıcıları filtrele
            var filtrelenmisKullanicilar = tumKullanicilar
                .Where(k => identityKullanicilar.Any(u => u.Id == k.IdentityUserId))
                .ToList();

            // 4. Tüm randevuları al
            var randevular = await _mediator.Send(new GetAllRandevularQuery());

            // 5. Oturumdaki doktorun ID'sini al
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                TempData["ErrorMessage"] = "Kullanıcı kimliği bulunamadı. Lütfen tekrar giriş yapınız.";
                return RedirectToAction("Login", "Account", new { area = "" });
            }

            Guid doktorId = Guid.Parse(userId);

            // 6. Bu doktora ait randevuları filtrele
            var doktorRandevulari = randevular
                .Where(x => x.PsikiyatristId == doktorId)
                .ToList();

            // 7. Doktorun randevu yaptığı hastaları filtrele
            var doktorHastalari = filtrelenmisKullanicilar
                .Where(k => doktorRandevulari.Any(r => r.HastaId == Guid.Parse(k.IdentityUserId)))
                .ToList();

            // 8. View'a gönder
            return View(doktorHastalari);
        }

    }
}
