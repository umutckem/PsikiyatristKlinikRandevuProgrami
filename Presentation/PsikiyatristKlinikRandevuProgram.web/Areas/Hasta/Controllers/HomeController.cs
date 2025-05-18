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
        if(kullaniciBilgisi is not null)
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
        if (!ModelState.IsValid)
        {
            // Model geçersiz ise tekrar formu göster
            return View(kullanici);
        }

        // Burada kaydetme işlemi yapabilirsiniz (DbContext kullanarak)
        // await _context.kullanicis.AddAsync(kullanici);
        // await _context.SaveChangesAsync();

        // Başarılıysa başka sayfaya yönlendir
        return RedirectToAction("Index", "Home", new { area = "Hasta" });
    }
}


