using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Randevu.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Recete;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Doktor.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = "Doktor")]
    public class ReceteController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IReceteCommandService _receteCommandService;

        public ReceteController(IMediator mediator , IReceteCommandService receteCommandService)
        {
            _mediator = mediator;
            _receteCommandService = receteCommandService;
        }

        [HttpGet]
       
        public async Task<IActionResult> Index(int randevuId)
        {
            var randevular = await _mediator.Send(new GetAllRandevularQuery());
            var randevu = randevular.FirstOrDefault(x => x.Id == randevuId);

            if (randevu == null)
            {
                return NotFound();
            }

            var recete = new Recete
            {
                HastaId = randevu.HastaId,
                PsikiyatristId = randevu.PsikiyatristId,
                YazilmaTarihi = DateTime.Now // otomatik setlenebilir
            };

            return View(recete); // View'a boş Recete nesnesi gönderiyoruz
        }

        [HttpPost]
        public IActionResult Index(Recete recete)
        {
            if (!ModelState.IsValid)
            {
                return View(recete);
            }

            recete.YazilmaTarihi = DateTime.Now;

            _receteCommandService.AddRecete(recete); // void metod

            TempData["Success"] = "Reçete başarıyla oluşturuldu.";
            return RedirectToAction("Index", "Notlar", new { area = "Doktor" });
        }

    }
}
