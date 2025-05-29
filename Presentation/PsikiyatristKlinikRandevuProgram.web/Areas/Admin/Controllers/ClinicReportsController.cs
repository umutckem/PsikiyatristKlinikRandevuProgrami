using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.KlinikRapor.Queries;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ClinicReportsController : Controller
    {
        private readonly IMediator _mediator;

        public ClinicReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(Guid id)
        {
            var klinikRaporları = await _mediator.Send(new GetAllKlinikRaporlarQuery());
            var kullaniciKlinikRaporları = klinikRaporları.Where(x => x.HastaId == id);
            return View(kullaniciKlinikRaporları);
        }
    }
}
