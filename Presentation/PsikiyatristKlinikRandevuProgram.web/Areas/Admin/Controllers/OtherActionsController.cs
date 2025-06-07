using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OtherActionsController : Controller
    {
        private readonly KullaniciServiceAdapter _kullaniciAdapter;

        public OtherActionsController(IKullaniciCommandService commandService, IKullaniciQueryService queryService)
        {
            _kullaniciAdapter = new KullaniciServiceAdapter(commandService, queryService);
        }

        public async Task<IActionResult> Index()
        {
            var kullanicilar = await _kullaniciAdapter.kullanicis(); 
            return View(kullanicilar);
        }
    }
}
