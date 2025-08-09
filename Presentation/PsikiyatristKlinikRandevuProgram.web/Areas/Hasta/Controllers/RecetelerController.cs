using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Application.Kullanici.Queries;
using PsikiyatristKlinikRandevuProgrami.Application.Randevu.Queries;
using PsikiyatristKlinikRandevuProgrami.Application.Recete.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Hasta.Controllers
{
    [Area("Hasta")]
    [Authorize(Roles = "Hasta")]
    public class RecetelerController : Controller
    {
        private readonly IMediator _mediator;

        public RecetelerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var receteler = await _mediator.Send(new GetAllRecetelerQuery());
            var kullanicilar = await _mediator.Send(new GetAllKullanicilarQuery());

            string userIdStr = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (!Guid.TryParse(userIdStr, out Guid userId))
            {
                return BadRequest("Geçersiz kullanıcı ID");
            }

            var kullaniciReceteleri = receteler.Where(x => x.HastaId == userId).ToList();

            var doktorAdlari = kullanicilar
                .Where(k => kullaniciReceteleri.Select(r => r.PsikiyatristId).Contains(Guid.Parse(k.IdentityUserId)))
                .ToDictionary(k => Guid.Parse(k.IdentityUserId), k => k.Ad + " " + k.Soyad);

            ViewBag.DoktorAdlari = doktorAdlari;

            return View(kullaniciReceteleri);
        }






    }
}
