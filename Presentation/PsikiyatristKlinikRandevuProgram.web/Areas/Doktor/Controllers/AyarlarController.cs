using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Doktor.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = "Doktor")]
    public class AyarlarController : Controller
    {
        private readonly IKullaniciQueryService _kullaniciQueryService;
        private readonly IKullaniciCommandService _kullaniciCommandService;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AyarlarController> _logger;

        public AyarlarController(
            IKullaniciQueryService kullaniciQueryService,
            IKullaniciCommandService kullaniciCommandService,
            ILogger<AyarlarController> logger,
            ApplicationDbContext context)
        {
            _kullaniciQueryService = kullaniciQueryService ?? throw new ArgumentNullException(nameof(kullaniciQueryService));
            _kullaniciCommandService = kullaniciCommandService ?? throw new ArgumentNullException(nameof(kullaniciCommandService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var identityId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(identityId))
                {
                    _logger.LogWarning("Ayarlar Index: Kullanıcı kimliği bulunamadı.");
                    TempData["ErrorMessage"] = "Kullanıcı kimliği bulunamadı. Lütfen tekrar giriş yapınız.";
                    return RedirectToAction("Login", "Account", new { area = "" });
                }

                var kullaniciListesi = await _kullaniciQueryService.GetAllKullanicilar();
                var kullanici = kullaniciListesi.FirstOrDefault(x => x.IdentityUserId == identityId);

                if (kullanici == null)
                {
                    _logger.LogWarning($"Ayarlar Index: Doktor bulunamadı, IdentityUserId: {identityId}");
                    TempData["ErrorMessage"] = "Profil bilgileriniz bulunamadı.";
                    return RedirectToAction("BilgiGirisi", "Home", new { area = "Doktor" });
                }

                return View(kullanici);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ayarlar Index: Hata oluştu.");
                TempData["ErrorMessage"] = "Bilgiler yüklenirken hata oluştu.";
                return RedirectToAction("Index", "Home", new { area = "Doktor" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Duzenle()
        {
            try
            {
                var identityId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(identityId))
                {
                    TempData["ErrorMessage"] = "Kullanıcı kimliği bulunamadı.";
                    return RedirectToAction("Login", "Account", new { area = "" });
                }

                var kullaniciListesi = await _kullaniciQueryService.GetAllKullanicilar();
                var kullanici = kullaniciListesi.FirstOrDefault(x => x.IdentityUserId == identityId);

                if (kullanici == null)
                {
                    TempData["ErrorMessage"] = "Kullanıcı bilgileri bulunamadı.";
                    return RedirectToAction("BilgiGirisi", "Home", new { area = "Doktor" });
                }

                return View(kullanici);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Duzenle (GET): Hata oluştu.");
                TempData["ErrorMessage"] = "Düzenleme ekranı yüklenemedi.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(Kullanici kullanici)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Geçersiz bilgiler girdiniz.";
                return View(kullanici);
            }

            try
            {
                var identityId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(identityId))
                {
                    TempData["ErrorMessage"] = "Kullanıcı kimliği bulunamadı.";
                    return RedirectToAction("Login", "Account", new { area = "" });
                }

                kullanici.IdentityUserId = identityId;
                var mevcutKullanici = (await _kullaniciQueryService.GetAllKullanicilar())
                                        .FirstOrDefault(x => x.IdentityUserId == identityId);

                if (mevcutKullanici != null)
                {
                    kullanici.Id = mevcutKullanici.Id;
                    _context.Entry(mevcutKullanici).State = EntityState.Detached;
                }

                await _kullaniciCommandService.UpdateKullanici(kullanici);
                TempData["SuccessMessage"] = "Bilgileriniz başarıyla güncellendi.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Duzenle (POST): Güncelleme hatası.");
                TempData["ErrorMessage"] = "Güncelleme sırasında bir hata oluştu.";
                return View(kullanici);
            }
        }
    }
}
