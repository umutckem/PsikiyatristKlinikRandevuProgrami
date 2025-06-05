using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Application.Recete.Queries;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PrescriptionsController : Controller
    {
        private readonly IReceteCommandService _receteCommandService;
        private readonly IReceteQueryService _receteQueryService;
        private readonly IMediator _mediator;

        public PrescriptionsController(IMediator mediator, IReceteCommandService receteCommandService, IReceteQueryService receteQueryService)
        {
            _mediator = mediator;
            _receteCommandService = receteCommandService;
            _receteQueryService = receteQueryService;
        }

        public async Task<IActionResult> Index(Guid id)
        {
            var receteler = await _mediator.Send(new GetAllRecetelerQuery());
            var kullaniciReceteleri = receteler.Where(x => x.HastaId == id);
            return View(kullaniciReceteleri);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var receteler = _receteQueryService.GetAllReceteler();
            var silinecekRecete = receteler.FirstOrDefault(x => x.Id == id);
            if(silinecekRecete is not null)
            {
                _receteCommandService.DeleteRecete(id);
                TempData["Message"] = "Reçete başarıyla silindi.";

                return RedirectToAction("Index", "User", new { area = "Admin" });
            }
            return RedirectToAction("Index", "User", new { area = "Admin" });
        }
    }
}
