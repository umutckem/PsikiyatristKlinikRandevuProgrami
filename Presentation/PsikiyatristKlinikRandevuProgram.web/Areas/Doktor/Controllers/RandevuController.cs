using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Doktor.Controllers
{
    public class RandevuController : Controller
    {
        [Area("Doktor")]
        [Authorize(Roles = "Doktor")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
