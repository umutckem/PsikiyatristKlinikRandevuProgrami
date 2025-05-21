using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Application.Randevu.Queries;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Hasta.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = "Doktor")]
    public class HomeController : Controller
    {
        private readonly IKullaniciQueryService _kullaniciQueryService;
        private readonly IKullaniciCommandService _kullaniciCommandService;
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator , IKullaniciQueryService kullaniciQueryService , IKullaniciCommandService kullaniciCommandService)
        {
            _mediator = mediator;
            _kullaniciQueryService = kullaniciQueryService;
            _kullaniciCommandService = kullaniciCommandService;
        }

        public async Task<IActionResult> Index()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userIdStr, out var psikiyatristId))
                return Unauthorized();

            

            var Doktorlar = await _kullaniciQueryService.GetAllKullanicilar();
            var DoktorBilgisi = Doktorlar.FirstOrDefault(x => x.IdentityUserId == userIdStr);

            ViewBag.DoktorAdi = DoktorBilgisi.Ad;
            ViewBag.DoktorSoyadi = DoktorBilgisi.Soyad;


            var randevular = await _mediator.Send(new GetRandevularByPsikiyatristIdQuery(psikiyatristId));
            return View(randevular);
        }
    }
}
