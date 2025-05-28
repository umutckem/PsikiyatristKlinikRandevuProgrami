using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Features.Bildirim.Query;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Doktor.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = "Doktor")]
    public class BildirimlerController : Controller
    {
        private readonly IMediator _mediator;

        public BildirimlerController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userIdStr, out var psikiyatristId))
                return Unauthorized();

            var bildirimler = await _mediator.Send(new GetAllBildirimlerQuery());

            // Psikiyatriste ait bildirimleri filtrele
            var doktorBildirimleri = bildirimler
                .Where(b => b.AliciKullaniciId == psikiyatristId)
                .ToList();

            return View(doktorBildirimleri); // Bildirim listesini view'e gönder
        }
    }
}
