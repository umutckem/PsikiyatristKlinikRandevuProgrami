using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Application.Randevu.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Hasta.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = "Doktor")]
    public class HomeController : Controller
    {
        private readonly IKullaniciQueryService _kullaniciQueryService;
        private readonly IKullaniciCommandService _kullaniciCommandService;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IRandevuQueryService _randevuQueryService;
        private readonly ICommandFacade _commandFacade;
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator , IKullaniciQueryService kullaniciQueryService , IKullaniciCommandService kullaniciCommandService, ICommandFacade commandFacade, IRandevuQueryService randevuQueryService, ApplicationDbContext applicationDbContext )
        {
            _mediator = mediator;
            _kullaniciQueryService = kullaniciQueryService;
            _kullaniciCommandService = kullaniciCommandService;
            _commandFacade = commandFacade;
            _applicationDbContext = applicationDbContext;
            _randevuQueryService = randevuQueryService;
        }

        public async Task<IActionResult> Index()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userIdStr, out var psikiyatristId))
                return Unauthorized();

            

            var Doktorlar = await _kullaniciQueryService.GetAllKullanicilar();
            var DoktorBilgisi = Doktorlar.FirstOrDefault(x => x.IdentityUserId == userIdStr);

            ViewBag.DoktorAdi = DoktorBilgisi.Ad;
            ViewBag.DoktorSoyadi = DoktorBilgisi.Soyad;


            var randevular = await _mediator.Send(new GetRandevularByPsikiyatristIdQuery(psikiyatristId));
            return View(randevular);
        }

        [HttpPost]
        public async Task<IActionResult> Onayla(int id, string durum) // id artık Guid oldu
        {
            var randevu = await _applicationDbContext.randevus.FindAsync(id);

            if (randevu != null)
            {
                randevu.Durum = durum;
                await _applicationDbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult BildirimGonder(int randevuId)
        {
            var randevu = _applicationDbContext.randevus.Find(randevuId);

            if (randevu != null)
            {
                // Bildirim nesnesi oluştur
                var bildirim = new Bildirim
                {
                    AliciKullaniciId = randevu.HastaId,
                    Tur = "Randevu",
                    Icerik = $"Sayın hasta, {randevu.TarihSaat:dd.MM.yyyy HH:mm} tarihli randevunuz hakkında bilgilendirme.",
                    GonderimYontemi = "Sistemİçi" // veya "E-Posta" gibi başka bir değer
                };

                // BildirimObserver sınıfını kullanarak bildirimi işle
                var observer = new BildirimObserver(_applicationDbContext);
                observer.Update(bildirim);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Sil(int randevuId)
        {
            var randevu = _applicationDbContext.randevus.Find(randevuId);

            if (randevu != null)
            {
                _applicationDbContext.randevus.Remove(randevu);
                _applicationDbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }









    }
}
