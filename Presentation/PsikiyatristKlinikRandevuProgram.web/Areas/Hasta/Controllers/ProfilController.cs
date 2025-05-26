using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Hasta.Controllers
{
    [Area("Hasta")]
    [Authorize(Roles = "Hasta")]
    public class ProfilController : Controller
    {
        private readonly IKullaniciQueryService _kullaniciQueryService;
        private readonly IKullaniciCommandService _kullaniciCommandService;
        private readonly ILogger<ProfilController> _logger;

        public ProfilController(IKullaniciQueryService kullaniciQueryService, IKullaniciCommandService kullaniciCommandService, ILogger<ProfilController> logger)
        {
            _kullaniciQueryService = kullaniciQueryService ?? throw new ArgumentNullException(nameof(kullaniciQueryService));
            _kullaniciCommandService = kullaniciCommandService ?? throw new ArgumentNullException(nameof(kullaniciCommandService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var identityId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(identityId))
                {
                    _logger.LogWarning("Index: Kullanıcı kimliği bulunamadı.");
                    TempData["ErrorMessage"] = "Kullanıcı kimliği bulunamadı. Lütfen tekrar oturum açın.";
                    return RedirectToAction("Login", "Account", new { area = "" });
                }

                _logger.LogInformation($"Index: Kullanıcı kimliği alındı, IdentityUserId: {identityId}");
                var kullaniciBilgisi = await _kullaniciQueryService.GetAllKullanicilar();
                var kullanici = kullaniciBilgisi.FirstOrDefault(x => x.IdentityUserId == identityId);

                if (kullanici == null)
                {
                    _logger.LogWarning($"Index: Kullanıcı bulunamadı, IdentityUserId: {identityId}");
                    TempData["ErrorMessage"] = "Profil bilgileri bulunamadı. Lütfen bilgilerinizi giriniz.";
                    return RedirectToAction("BilgiGirisi", "Home", new { area = "Hasta" });
                }

                _logger.LogInformation($"Index: Kullanıcı bulundu, Id: {kullanici.Id}");
                return View(kullanici);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Index: Profil bilgileri getirilirken hata oluştu.");
                TempData["ErrorMessage"] = "Profil bilgileri yüklenirken bir hata oluştu.";
                return RedirectToAction("Index", "Home", new { area = "Hasta" });
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
                    _logger.LogWarning("Duzenle: Kullanıcı kimliği bulunamadı.");
                    TempData["ErrorMessage"] = "Kullanıcı kimliği bulunamadı. Lütfen tekrar oturum açın.";
                    return RedirectToAction("Login", "Account", new { area = "" });
                }

                _logger.LogInformation($"Duzenle: Kullanıcı kimliği alındı, IdentityUserId: {identityId}");
                var kullaniciBilgisi = await _kullaniciQueryService.GetAllKullanicilar();
                var kullanici = kullaniciBilgisi.FirstOrDefault(x => x.IdentityUserId == identityId);

                if (kullanici == null)
                {
                    _logger.LogWarning($"Duzenle: Kullanıcı bulunamadı, IdentityUserId: {identityId}");
                    TempData["ErrorMessage"] = "Profil bilgileri bulunamadı. Lütfen bilgilerinizi giriniz.";
                    return RedirectToAction("BilgiGirisi", "Home", new { area = "Hasta" });
                }

                _logger.LogInformation($"Duzenle: Kullanıcı bulundu, Id: {kullanici.Id}");
                return View(kullanici);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Duzenle: Profil düzenleme sayfası yüklenirken hata oluştu.");
                TempData["ErrorMessage"] = "Profil düzenleme sayfası yüklenirken bir hata oluştu.";
                return RedirectToAction("Index", "Home", new { area = "Hasta" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(Kullanici kullanici)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                _logger.LogWarning($"Duzenle POST: Validasyon hataları: {string.Join("; ", errors)}");
                TempData["ErrorMessage"] = string.Join("; ", errors);
                return View(kullanici);
            }

            try
            {
                var identityId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(identityId))
                {
                    _logger.LogWarning("Duzenle POST: Kullanıcı kimliği bulunamadı.");
                    TempData["ErrorMessage"] = "Kullanıcı kimliği bulunamadı. Lütfen tekrar oturum açın.";
                    return RedirectToAction("Login", "Account", new { area = "" });
                }

                kullanici.IdentityUserId = identityId;
                await _kullaniciCommandService.UpdateKullanici(kullanici);

                _logger.LogInformation($"Duzenle POST: Kullanıcı güncellendi, Id: {kullanici.Id}");
                TempData["SuccessMessage"] = "Profil bilgileriniz başarıyla güncellendi.";
                return RedirectToAction("Index", "Profil", new { area = "Hasta" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Duzenle POST: Güncelleme sırasında hata oluştu, Kullanıcı Id: {kullanici.Id}");
                TempData["ErrorMessage"] = $"Güncelleme sırasında bir hata oluştu: {ex.Message}";
                return View(kullanici);
            }
        }
    }
}