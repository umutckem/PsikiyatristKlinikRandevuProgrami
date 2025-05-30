using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using PsikiyatristKlinikRandevuProgrami.Core.Model;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            var kullanicilar = _applicationDbContext.kullanicis.ToList();
            var userRoles = _applicationDbContext.UserRoles.ToList();
            var roles = _applicationDbContext.Roles.ToList();

            // IdentityUserId → List of RolAdı
            var kullaniciRolleri = new Dictionary<string, List<string>>();

            foreach (var kullanici in kullanicilar)
            {
                var userId = kullanici.IdentityUserId;

                if (string.IsNullOrEmpty(userId))
                {
                    kullaniciRolleri[userId ?? ""] = new List<string> { "Tanımsız" };
                    continue;
                }

                var roller = userRoles
                    .Where(ur => ur.UserId == userId)
                    .Select(ur => roles.FirstOrDefault(r => r.Id == ur.RoleId)?.Name)
                    .Where(r => !string.IsNullOrEmpty(r))
                    .ToList();

                if (!roller.Any())
                    roller.Add("Tanımsız");

                kullaniciRolleri[userId] = roller!;
            }

            ViewBag.KullaniciRolleri = kullaniciRolleri;
            return View(kullanicilar);
        }

        [HttpGet]
        public IActionResult ChangeRole(Guid id)
        {
            var kullanici = _applicationDbContext.kullanicis
                .FirstOrDefault(x => x.IdentityUserId == id.ToString());

            if (kullanici == null) return NotFound();

            var userRoles = _applicationDbContext.UserRoles
                .Where(ur => ur.UserId == kullanici.IdentityUserId)
                .ToList();

            var currentRoles = userRoles
                .Select(ur => _applicationDbContext.Roles.FirstOrDefault(r => r.Id == ur.RoleId)?.Name)
                .Where(r => r != null)
                .ToList();

            var tumRoller = _applicationDbContext.Roles.Select(r => r.Name).ToList();

            ViewBag.Kullanici = kullanici;
            ViewBag.AktifRol = string.Join(", ", currentRoles);
            ViewBag.TumRoller = tumRoller;

            return View("ChangeRole");
        }

        [HttpPost]
        public IActionResult ChangeRole(string identityUserId, string yeniRol)
        {
            if (string.IsNullOrEmpty(identityUserId) || string.IsNullOrEmpty(yeniRol))
                return BadRequest();

            var userRoles = _applicationDbContext.UserRoles
                .Where(ur => ur.UserId == identityUserId)
                .ToList();

            var yeniRolId = _applicationDbContext.Roles
                .FirstOrDefault(r => r.Name == yeniRol)?.Id;

            if (string.IsNullOrEmpty(yeniRolId))
                return BadRequest("Rol bulunamadı.");

            // Eğer zaten bu role sahipse işlem yapma
            bool alreadyInRole = userRoles.Any(ur => ur.RoleId == yeniRolId);
            if (alreadyInRole)
            {
                TempData["Message"] = "Kullanıcı zaten bu role sahip.";
                return RedirectToAction("Index");
            }

            // Tüm rolleri sil (tek rol desteği varsa)
            if (userRoles.Any())
                _applicationDbContext.UserRoles.RemoveRange(userRoles);

            // Yeni rolü ata
            _applicationDbContext.UserRoles.Add(new IdentityUserRole<string>
            {
                UserId = identityUserId,
                RoleId = yeniRolId
            });

            _applicationDbContext.SaveChanges();
            TempData["Message"] = "Rol başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteUser(Guid id)
        {
            // IdentityUserId string olduğu için Guid'i ToString ile karşılaştır
            var kullanici = _applicationDbContext.kullanicis.FirstOrDefault(x => x.IdentityUserId == id.ToString());
            var identityUser = _applicationDbContext.Users.FirstOrDefault(x => x.Id == id.ToString());

            if (kullanici != null)
                _applicationDbContext.kullanicis.Remove(kullanici);

            if (identityUser != null)
                _applicationDbContext.Users.Remove(identityUser);

            // Değişiklikleri tek seferde kaydet
            _applicationDbContext.SaveChanges();

            TempData["Message"] = "Kullanıcı başarıyla silindi.";
            return RedirectToAction("Index");
        }

    }
}
