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
        if (string.IsNullOrWhiteSpace(kullanici.Ad))
        {
            ModelState.AddModelError("Ad", "Ad boş bırakılamaz.");
        }
        else if (kullanici.Ad.Length > 50)
        {
            ModelState.AddModelError("Ad", "Ad en fazla 50 karakter olabilir.");
        }

        if (string.IsNullOrWhiteSpace(kullanici.Soyad))
        {
            ModelState.AddModelError("Soyad", "Soyad boş bırakılamaz.");
        }
        else if (kullanici.Soyad.Length > 50)
        {
            ModelState.AddModelError("Soyad", "Soyad en fazla 50 karakter olabilir.");
        }

        if (kullanici.DogumTarihi == default)
        {
            ModelState.AddModelError("DogumTarihi", "Doğum tarihi zorunludur.");
        }
        else if (kullanici.DogumTarihi > DateTime.Now)
        {
            ModelState.AddModelError("DogumTarihi", "Doğum tarihi gelecekte olamaz.");
        }

        if (string.IsNullOrWhiteSpace(kullanici.Cinsiyet))
        {
            ModelState.AddModelError("Cinsiyet", "Lütfen bir cinsiyet seçiniz.");
        }
        else if (kullanici.Cinsiyet.Length > 10)
        {
            ModelState.AddModelError("Cinsiyet", "Cinsiyet en fazla 10 karakter olabilir.");
        }

        if (string.IsNullOrWhiteSpace(kullanici.Adres))
        {
            ModelState.AddModelError("Adres", "Adres bilgisi gerekli.");
        }
        else if (kullanici.Adres.Length > 200)
        {
            ModelState.AddModelError("Adres", "Adres en fazla 200 karakter olabilir.");
        }

        if (string.IsNullOrWhiteSpace(kullanici.SigortaDurumu))
        {
            ModelState.AddModelError("SigortaDurumu", "Sigorta durumu boş olamaz.");
        }
        else if (kullanici.SigortaDurumu.Length > 50)
        {
            ModelState.AddModelError("SigortaDurumu", "Sigorta durumu en fazla 50 karakter olabilir.");
        }

        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            // breakpoint koy, errors listesini incele
            return View(kullanici);
        }

        kullanici.Id = Guid.NewGuid();

        var identityId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (identityId != null)
        {
            kullanici.IdentityUserId = identityId;
        }

        await _kullaniciCommandService.AddKullanici(kullanici);

        return RedirectToAction("Index", "Home", new { area = "Hasta" });
    }
}


