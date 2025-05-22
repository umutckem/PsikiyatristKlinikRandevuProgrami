using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Odeme.Queries;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Hasta.Controllers
{
    [Area("Hasta")]
    [Authorize(Roles = "Hasta")]
    public class OdemeController : Controller
    {
        private readonly IMediator _mediator;

        public OdemeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var odemeler = await _mediator.Send(new GetAllOdemelerQuery());

            string userIdStr = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (!Guid.TryParse(userIdStr, out Guid userId))
            {
                return BadRequest("Geçersiz kullanıcı ID");
            }

            // HastaId Guid türünde olduğuna göre, doğrudan karşılaştırabiliriz.
            var kullaniciOdemeleri = odemeler
                .Where(x => x.HastaId == userId)
                .ToList();

            return View(kullaniciOdemeleri);
        }


    }
}
