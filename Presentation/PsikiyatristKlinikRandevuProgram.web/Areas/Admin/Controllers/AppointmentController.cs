using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Randevu.Queries;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AppointmentController : Controller
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(Guid id)
        {
            var Randevular = await _mediator.Send(new GetAllRandevularQuery());
            var kullaniciRandevuları = Randevular.Where(x => x.HastaId == id);
            return View(kullaniciRandevuları);
        }
    }
}
