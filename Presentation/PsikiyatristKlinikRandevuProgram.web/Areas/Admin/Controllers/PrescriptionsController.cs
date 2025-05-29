using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Recete.Queries;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PrescriptionsController : Controller
    {
        private readonly IMediator _mediator;

        public PrescriptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(Guid id)
        {
            var receteler = await _mediator.Send(new GetAllRecetelerQuery());
            var kullaniciReceteleri = receteler.Where(x => x.HastaId == id);
            return View(kullaniciReceteleri);
        }
    }
}
