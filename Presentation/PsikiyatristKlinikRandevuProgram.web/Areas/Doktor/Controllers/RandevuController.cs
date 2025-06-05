using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Doktor.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = "Doktor")]
    public class RandevuController : Controller
    {
        private readonly IRandevuQueryService _randevuQueryService;

        public RandevuController(IRandevuQueryService randevuQueryService)
        {
            _randevuQueryService = randevuQueryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            var doctorId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var randevular = _randevuQueryService.GetRandevularByPsikiyatristId(doctorId);

            
            ViewBag.DoktorAdi = "Doktor"; 
            ViewBag.DoktorSoyadi = "Soyadı";

            return View(randevular);
        }

        [HttpGet]
        public IActionResult GetRandevuById(int id)
        {
            var randevu = _randevuQueryService.GetAllRandevular()
                .FirstOrDefault(r => r.Id == id && r.PsikiyatristId == Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            if (randevu == null)
            {
                return NotFound();
            }
            return Json(new
            {
                id = randevu.Id,
                tarihSaat = randevu.TarihSaat.ToString("dd.MM.yyyy HH:mm"),
                durum = randevu.Durum,
                aciklama = randevu.Aciklama
            });
        }
    }
}