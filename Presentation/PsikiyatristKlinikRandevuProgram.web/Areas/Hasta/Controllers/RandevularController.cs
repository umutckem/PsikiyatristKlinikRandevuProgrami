using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using PsikiyatristKlinikRandevuProgrami.Web.Hubs;
using System;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;
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
        private readonly IHubContext<AppointmentHub> _hubContext;

        public RandevularController(
            IRandevuQueryService randevuQueryService,
            IRandevuCommandService randevuCommandService,
            IMediator mediator,
            ApplicationDbContext context,
            IHubContext<AppointmentHub> hubContext)
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
            var doktorUserIds = await _context.UserRoles
                .Where(x => x.RoleId == "b867058d-f804-456c-91cf-ef30821df712")
                .Select(x => x.UserId)
                .ToListAsync();

            var doktorlar = await _context.kullanicis
                .Where(k => doktorUserIds.Contains(k.IdentityUserId))
                .Select(k => new
                {
                    k.IdentityUserId,
                    k.Ad,
                    k.Soyad
                })
                .ToListAsync();

            var hastaId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var randevular = _randevuQueryService.GetAllRandevular()
                .FindAll(r => r.HastaId == hastaId);

            ViewBag.Doktorlar = doktorlar;
            ViewBag.Randevular = randevular;

            return View();
        }

        [HttpGet]
        public IActionResult GetRandevuById(int id)
        {
            var hastaId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var randevu = _randevuQueryService.GetAllRandevular()
                .FirstOrDefault(r => r.Id == id && r.HastaId == hastaId);

            if (randevu == null)
                return NotFound();

            return Json(new
            {
                id = randevu.Id,
                tarihSaat = randevu.TarihSaat.ToString("g"),
                durum = randevu.Durum,
                aciklama = randevu.Aciklama
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RandevuOlustur(Randevu model)
        {
            try
            {
                model.Durum = "Beklemede";
                model.HastaId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();

                    Console.WriteLine($"ModelState Errors: {string.Join(", ", errors)}");
                    var hastaId = model.HastaId;
                    ViewBag.Randevular = _randevuQueryService.GetAllRandevular()
                        .FindAll(r => r.HastaId == hastaId);
                    return View("Index", model);
                }

                _randevuCommandService.AddRandevu(model);

                var savedRandevu = _context.randevus.FirstOrDefault(r => r.Id == model.Id);
                if (savedRandevu == null)
                {
                    ModelState.AddModelError("", "Randevu kaydedilemedi.");
                    var hastaId = model.HastaId;
                    ViewBag.Randevular = _randevuQueryService.GetAllRandevular()
                        .FindAll(r => r.HastaId == hastaId);
                    return View("Index", model);
                }

                var hasta = _context.kullanicis
                    .FirstOrDefault(k => k.IdentityUserId == model.HastaId.ToString());

                var hastaAdi = hasta != null ? $"{hasta.Ad} {hasta.Soyad}" : User.Identity.Name;

                var doctorUserId = model.PsikiyatristId.ToString();
                var message = $"Yeni randevu: {model.TarihSaat:dd.MM.yyyy HH:mm} - Hasta: {hastaAdi} | RandevuId: {model.Id}";
                _hubContext.Clients.User(doctorUserId)
                    .SendAsync("ReceiveAppointmentNotification", message);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in RandevuOlustur: {ex.Message}\n{ex.StackTrace}");
                ModelState.AddModelError("", "Randevu oluşturulurken bir hata oluştu: " + ex.Message);
                var hastaId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                ViewBag.Randevular = _randevuQueryService.GetAllRandevular()
                    .FindAll(r => r.HastaId == hastaId);
                return View("Index", model);
            }
        }

        [HttpGet]
        public IActionResult GetAvailableSlots(string psikiyatristId)
        {
            if (string.IsNullOrEmpty(psikiyatristId))
                return BadRequest();

            var allRandevular = _randevuQueryService.GetAllRandevular()
                .Where(r => r.PsikiyatristId.ToString() == psikiyatristId)
                .Select(r => r.TarihSaat)
                .ToList();

            var now = DateTime.Now;
            var result = new Dictionary<string, List<object>>();
            var culture = new System.Globalization.CultureInfo("tr-TR");

            for (int day = 0; day < 15; day++)
            {
                var currentDate = now.Date.AddDays(day);
                var gunlukList = new List<object>();

                for (int hour = 8; hour < 16; hour++)
                {
                    for (int minute = 0; minute < 60; minute += 30)
                    {
                        var slot = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, hour, minute, 0);

                        if (slot <= now) continue;

                        if (!allRandevular.Any(r => r == slot))
                        {
                            gunlukList.Add(new
                            {
                                raw = slot.ToString("s"),
                                label = slot.ToString("HH:mm")
                            });
                        }
                    }
                }

                if (gunlukList.Any())
                {
                    var gunBasligi = currentDate.ToString("dddd, dd MMMM yyyy", culture);
                    result.Add(gunBasligi, gunlukList);
                }
            }

            return Json(result);
        }
    }
}
