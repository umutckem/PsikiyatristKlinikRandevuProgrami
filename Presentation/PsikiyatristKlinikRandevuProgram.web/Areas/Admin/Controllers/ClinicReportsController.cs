using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.KlinikRapor.Queries;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Randevu;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ClinicReportsController : Controller
    {
        private readonly IKlinikRaporCommandService _klinikRaporCommandService;
        private readonly IMediator _mediator;

        public ClinicReportsController(IMediator mediator, IKlinikRaporCommandService klinikRaporCommandService)
        {
            _mediator = mediator;
            _klinikRaporCommandService = klinikRaporCommandService;
        }

        public async Task<IActionResult> Index(Guid id)
        {
            var klinikRaporları = await _mediator.Send(new GetAllKlinikRaporlarQuery());
            var kullaniciKlinikRaporları = klinikRaporları.Where(x => x.HastaId == id);
            return View(kullaniciKlinikRaporları);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                _klinikRaporCommandService.DeleteKlinikRapor(id);
            }
            return RedirectToAction("Index", "User", new { area = "Admin" });
        }
    }
}
