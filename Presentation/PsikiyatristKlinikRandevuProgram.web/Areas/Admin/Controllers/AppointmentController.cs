using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Randevu.Queries;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AppointmentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IRandevuCommandService _randevuCommandService;

        public AppointmentController(IMediator mediator, IRandevuCommandService randevuCommandService)
        {
            _mediator = mediator;
            _randevuCommandService = randevuCommandService;
        }

        public async Task<IActionResult> Index(Guid id)
        {
            var Randevular = await _mediator.Send(new GetAllRandevularQuery());
            var kullaniciRandevuları = Randevular.Where(x => x.HastaId == id);
            return View(kullaniciRandevuları);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(id != 0)
            {
                _randevuCommandService.DeleteRandevu(id);
            }
            return RedirectToAction("Index", "User", new { area = "Admin" });
        }
    }
}
