using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Hasta.Controllers
{
    [Area("Hasta")]
    [Authorize(Roles = "Hasta")]
    public class RandevularController : Controller
    {
        private readonly IRandevuCommandService _randevuCommandService;
        private readonly IRandevuQueryService _randevuQueryService;
        private IMediator _mediator;
        private readonly ApplicationDbContext _context;

        public RandevularController(IRandevuQueryService randevuQueryService, IRandevuCommandService randevuCommandService, IMediator mediator, ApplicationDbContext context)
        {
            _randevuQueryService = randevuQueryService;
            _randevuCommandService = randevuCommandService;
            _mediator = mediator;
            _context = context;
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
            model.Durum = "False";
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

            // Bildirim oluşturma kısmı burada olmalı (eğer varsa bildirim servisi)

            return RedirectToAction("Index");
        }
    }
}
