using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IKullaniciQueryService _kullaniciQueryService;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(IKullaniciQueryService kullaniciQueryService, ApplicationDbContext dbContext)
        {
            _kullaniciQueryService = kullaniciQueryService;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var kullanıcılar = _dbContext.kullanicis.ToList();
            var roller = _dbContext.Roles.ToList();
            var userRoles = _dbContext.UserRoles.ToList();

            var hastaRol = roller.FirstOrDefault(x => x.Name == "Hasta");
            var doktorRol = roller.FirstOrDefault(x => x.Name == "Doktor");

            ViewBag.ToplamKullanici = kullanıcılar.Count();
            ViewBag.HastaSayisi = hastaRol != null ? userRoles.Count(x => x.RoleId == hastaRol.Id) : 0;
            ViewBag.DoktorSayisi = doktorRol != null ? userRoles.Count(x => x.RoleId == doktorRol.Id) : 0;
            ViewBag.RandevuSayisi = _dbContext.randevus.Count(); // isim doğruysa

            return View();
        }
    }
}
