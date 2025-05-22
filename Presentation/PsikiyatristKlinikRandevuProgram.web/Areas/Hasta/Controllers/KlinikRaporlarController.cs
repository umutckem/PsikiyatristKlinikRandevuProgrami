using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.KlinikRapor.Queries;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Hasta.Controllers
{
    [Area("Hasta")]
    [Authorize(Roles = "Hasta")]
    public class KlinikRaporlarController : Controller
    {
        private readonly IMediator _mediator;

        public KlinikRaporlarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var KlinikRaporları = await _mediator.Send(new GetAllKlinikRaporlarQuery());

            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (!Guid.TryParse(userId, out Guid parsedUserId))
            {
                return BadRequest("Geçersiz kullanıcı ID.");
            }

            var hastanınKlinikRaporları = KlinikRaporları
                .Where(x => x.HastaId == parsedUserId)
                .ToList();

            return View(hastanınKlinikRaporları);
        }


    }
}
