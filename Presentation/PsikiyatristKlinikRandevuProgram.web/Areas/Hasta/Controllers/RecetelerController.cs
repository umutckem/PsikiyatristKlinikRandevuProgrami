using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Hasta.Controllers
{
    [Area("Hasta")]
    [Authorize(Roles = "Hasta")]
    public class RecetelerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
