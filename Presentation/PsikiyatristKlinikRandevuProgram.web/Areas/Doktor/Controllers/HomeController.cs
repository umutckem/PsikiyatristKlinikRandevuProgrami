using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Application.Randevu.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services;
using PsikiyatristKlinikRandevuProgrami.Web.Hubs;
using RabbitMQ.Client;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Doktor.Controllers
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
        private readonly IHubContext<AppointmentHub> _hubContext;

        public HomeController(
            IMediator mediator,
            IKullaniciQueryService kullaniciQueryService,
            IKullaniciCommandService kullaniciCommandService,
            ICommandFacade commandFacade,
            IRandevuQueryService randevuQueryService,
            ApplicationDbContext applicationDbContext,
            IHubContext<AppointmentHub> hubContext)
        {
            _mediator = mediator;
            _kullaniciQueryService = kullaniciQueryService;
            _kullaniciCommandService = kullaniciCommandService;
            _commandFacade = commandFacade;
            _applicationDbContext = applicationDbContext;
            _randevuQueryService = randevuQueryService;
            _hubContext = hubContext;
        }

        public async Task<IActionResult> Index()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userIdStr, out var psikiyatristId))
                return Unauthorized();

            var Doktorlar = await _kullaniciQueryService.GetAllKullanicilar();
            var DoktorBilgisi = Doktorlar.FirstOrDefault(x => x.IdentityUserId == userIdStr);
            if (DoktorBilgisi == null)
            {
                return RedirectToAction("BilgiGirisi", "Home", new { area = "Doktor" });
            }
            ViewBag.DoktorAdi = DoktorBilgisi.Ad;
            ViewBag.DoktorSoyadi = DoktorBilgisi.Soyad;

            var randevular = await _mediator.Send(new GetRandevularByPsikiyatristIdQuery(psikiyatristId));
            return View(randevular);
        }

        [HttpPost]
        public async Task<IActionResult> Onayla(int id, string durum)
        {
            var randevu = await _applicationDbContext.randevus.FindAsync(id);

            if (randevu != null)
            {
                randevu.Durum = durum;
                await _applicationDbContext.SaveChangesAsync();

                // Send SignalR notification to the patient
                var hastaUserId = randevu.HastaId.ToString();
                var doktor = await _applicationDbContext.kullanicis
                    .FirstOrDefaultAsync(k => k.IdentityUserId == randevu.PsikiyatristId.ToString());
                var doktorAdi = doktor != null ? $"{doktor.Ad} {doktor.Soyad}" : "Doktor";
                var message = $"Randevunuz onaylandı: {randevu.TarihSaat:dd.MM.yyyy HH:mm} - Doktor: {doktorAdi} | RandevuId: {randevu.Id}";
                await _hubContext.Clients.User(hastaUserId)
                    .SendAsync("ReceiveApprovalNotification", message);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult BildirimGonder(int randevuId)
        {
            var randevu = _applicationDbContext.randevus.Find(randevuId);

            if (randevu != null)
            {
                var bildirim = new Bildirim
                {
                    AliciKullaniciId = randevu.HastaId,
                    Tur = "Randevu",
                    Icerik = $"Sayın hasta, {randevu.TarihSaat:dd.MM.yyyy HH:mm} tarihli randevunuz hakkında bilgilendirme.",
                    GonderimYontemi = "Sistemİçi"
                };

                var observer = new BildirimObserver(_applicationDbContext);
                observer.Update(bildirim);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Sil(int randevuId)
        {
            var randevu = await _applicationDbContext.randevus.FindAsync(randevuId);
            if (randevu != null)
            {
                // Get patient ID for SignalR notification
                var hastaUserId = randevu.HastaId.ToString();
                var doktor = await _applicationDbContext.kullanicis
                    .FirstOrDefaultAsync(k => k.IdentityUserId == randevu.PsikiyatristId.ToString());
                var doktorAdi = doktor != null ? $"{doktor.Ad} {doktor.Soyad}" : "Doktor";

                // Delete the appointment
                _applicationDbContext.randevus.Remove(randevu);
                await _applicationDbContext.SaveChangesAsync();

                // Send SignalR notification to the patient
                var message = $"Randevunuz iptal edildi: {randevu.TarihSaat:dd.MM.yyyy HH:mm} - Doktor: {doktorAdi} | RandevuId: {randevuId}";
                await _hubContext.Clients.User(hastaUserId)
                    .SendAsync("ReceiveDeletionNotification", message);

                // Optionally keep RabbitMQ for auditing
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(queue: "randevu_iptal_queue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var rabbitMessage = randevuId.ToString();
                var body = Encoding.UTF8.GetBytes(rabbitMessage);

                channel.BasicPublish(exchange: "",
                                     routingKey: "randevu_iptal_queue",
                                     basicProperties: null,
                                     body: body);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult BilgiGirisi()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BilgiGirisi(Kullanici kullanici)
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
            if (!ModelState.IsValid)
            {
                return View(kullanici);
            }
            kullanici.IdentityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _kullaniciCommandService.AddKullanici(kullanici);
            return RedirectToAction("Index");
        }
    }
}