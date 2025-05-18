using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services;
using System;
using System.Threading.Tasks;

[Area("Hasta")]
[Authorize(Roles = "Hasta")]
public class HomeController : Controller
{
    private readonly IKullaniciQueryService _kullaniciQueryService;
    private readonly IKullaniciCommandService _kullaniciCommandService;
    private readonly ApplicationDbContext _context;

    public HomeController(IKullaniciQueryService kullaniciQueryService, ApplicationDbContext context, IKullaniciCommandService kullaniciCommandService)
    {
        _kullaniciQueryService = kullaniciQueryService;
        _kullaniciCommandService = kullaniciCommandService;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var identityId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var kullaniciBilgisi = await _kullaniciQueryService.GetAllKullanicilar();
        var kullaniciBilgisiKontrol = kullaniciBilgisi.FirstOrDefault(x => x.IdentityUserId == identityId);
        if(kullaniciBilgisiKontrol == null)
        {
            return RedirectToAction("BilgiGirisi", "Home", new { area = "Hasta" });

        }
        return View();
    }


    [HttpGet]
    public IActionResult BilgiGirisi()
    {
        // Boş model gönderiyoruz, null referans önlemek için
        return View(new Kullanici());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> BilgiGirisi(Kullanici kullanici)
    {
        var identityId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if(identityId != null)
        {
            kullanici.IdentityUserId = identityId;
        }

        kullanici.Id = Guid.NewGuid(); // Yeni bir GUID oluştur

        // Özel validasyon kuralları
        if (string.IsNullOrWhiteSpace(kullanici.Ad))
        {
            ModelState.AddModelError("Ad", "Ad boş bırakılamaz.");
        }

        if (string.IsNullOrWhiteSpace(kullanici.Soyad))
        {
            ModelState.AddModelError("Soyad", "Soyad boş bırakılamaz.");
        }

        if (kullanici.DogumTarihi > DateTime.Now)
        {
            ModelState.AddModelError("DogumTarihi", "Doğum tarihi gelecekte olamaz.");
        }

        if (string.IsNullOrEmpty(kullanici.Cinsiyet))
        {
            ModelState.AddModelError("Cinsiyet", "Lütfen bir cinsiyet seçiniz.");
        }

        if (string.IsNullOrWhiteSpace(kullanici.Adres))
        {
            ModelState.AddModelError("Adres", "Adres bilgisi gerekli.");
        }

        if (string.IsNullOrWhiteSpace(kullanici.SigortaDurumu))
        {
            ModelState.AddModelError("SigortaDurumu", "Sigorta durumu boş olamaz.");
        }

        await _kullaniciCommandService.AddKullanici(kullanici);

        // Başarılıysa başka sayfaya yönlendir
        return RedirectToAction("Index", "Home", new { area = "Hasta" });
    }
}


