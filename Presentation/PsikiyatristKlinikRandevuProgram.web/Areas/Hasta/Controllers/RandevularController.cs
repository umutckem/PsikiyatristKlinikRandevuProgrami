using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services;
using System;
using System.Security.Claims;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Hasta.Controllers
{
    [Area("Hasta")]
    [Authorize(Roles = "Hasta")]
    public class RandevularController : Controller
    {
        private readonly IRandevuCommandService _randevuCommandService;
        private readonly IRandevuQueryService _randevuQueryService;

        public RandevularController(IRandevuQueryService randevuQueryService, IRandevuCommandService randevuCommandService)
        {
            _randevuQueryService = randevuQueryService;
            _randevuCommandService = randevuCommandService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var hastaId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var randevular = _randevuQueryService.GetAllRandevular()
                .FindAll(r => r.HastaId == hastaId);

            ViewBag.Randevular = randevular;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RandevuOlustur(Randevu model)
        {
            if (!ModelState.IsValid)
            {
                var hastaId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                ViewBag.Randevular = _randevuQueryService.GetAllRandevular()
                    .FindAll(r => r.HastaId == hastaId);
                return View("Index", model);
            }

            model.Id = 0;
            model.HastaId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            model.Durum = "Beklemede";

            _randevuCommandService.AddRandevu(model);

            // Bildirim oluşturma kısmı burada olmalı (eğer varsa bildirim servisi)

            return RedirectToAction("Index");
        }
    }
}
