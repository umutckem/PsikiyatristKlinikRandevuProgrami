using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR; // Add for SignalR
using Microsoft.EntityFrameworkCore;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using PsikiyatristKlinikRandevuProgrami.Web.Hubs; // Add for AppointmentHub
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Hasta.Controllers
{
    [Area("Hasta")]
    [Authorize(Roles = "Hasta")]
    public class RandevularController : Controller
    {
        private readonly IRandevuCommandService _randevuCommandService;
        private readonly IRandevuQueryService _randevuQueryService;
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<AppointmentHub> _hubContext; // Add IHubContext

        public RandevularController(
            IRandevuQueryService randevuQueryService,
            IRandevuCommandService randevuCommandService,
            IMediator mediator,
            ApplicationDbContext context,
            IHubContext<AppointmentHub> hubContext) // Inject IHubContext
        {
            _randevuQueryService = randevuQueryService;
            _randevuCommandService = randevuCommandService;
            _mediator = mediator;
            _context = context;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Doktorların userId'lerini al (roleId ile filtreli)
            var doktorUserIds = await _context.UserRoles
                .Where(x => x.RoleId == "b867058d-f804-456c-91cf-ef30821df712")
                .Select(x => x.UserId)
                .ToListAsync();

            // Doktorların Kullanici modeli karşılıklarını çek
            var doktorlar = await _context.kullanicis
                .Where(k => doktorUserIds.Contains(k.IdentityUserId))
                .Select(k => new
                {
                    k.IdentityUserId,
                    k.Ad,
                    k.Soyad
                })
                .ToListAsync();

            // Hasta ID
            var hastaId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            // Randevuları çek
            var randevular = _randevuQueryService.GetAllRandevular()
                .FindAll(r => r.HastaId == hastaId);

            // Doktorlar + randevular ViewBag içine koyabilirsin
            ViewBag.Doktorlar = doktorlar;
            ViewBag.Randevular = randevular;

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RandevuOlustur(Randevu model)
        {
            model.Durum = "Beklemede";
            model.HastaId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                              .Select(e => e.ErrorMessage)
                              .ToList();
                var hastaId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                ViewBag.Randevular = _randevuQueryService.GetAllRandevular()
                    .FindAll(r => r.HastaId == hastaId);
                return View("Index", model);
            }

            _randevuCommandService.AddRandevu(model);

            // Fetch patient name from Kullanici table
            var hasta = _context.kullanicis
                .FirstOrDefault(k => k.IdentityUserId == model.HastaId.ToString());
            var hastaAdi = hasta != null ? $"{hasta.Ad} {hasta.Soyad}" : User.Identity.Name;

            // Send SignalR notification to the doctor
            var doctorUserId = model.PsikiyatristId.ToString();
            var message = $"Yeni randevu: {model.TarihSaat:dd.MM.yyyy HH:mm} - Hasta: {hastaAdi} | RandevuId: {model.Id}";
            _hubContext.Clients.User(doctorUserId)
                .SendAsync("ReceiveAppointmentNotification", message);

            return RedirectToAction("Index");
        }
    }
}