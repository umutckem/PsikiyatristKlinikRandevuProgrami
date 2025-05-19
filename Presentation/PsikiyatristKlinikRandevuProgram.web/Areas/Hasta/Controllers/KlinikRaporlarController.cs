using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Hasta.Controllers
{
    [Area("Hasta")]
    [Authorize(Roles = "Hasta")]
    public class KlinikRaporlarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
