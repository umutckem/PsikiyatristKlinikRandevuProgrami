using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using System;
using System.Linq;
using System.Security.Claims;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Hasta.Controllers
{
    [Area("Hasta")]
    [Authorize(Roles = "Hasta")]
    public class GeriBildirimController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GeriBildirimController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Onaylanmış randevuları listeler
        public IActionResult Index()
        {
            var hastaId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var onayliRandevular = _context.randevus
                .Where(r => r.HastaId == hastaId && r.Durum == "Onaylandı")
                .OrderByDescending(r => r.TarihSaat)
                .ToList();

            return View(onayliRandevular);
        }

        // Geri bildirim formu
        [HttpGet]
        public IActionResult Gonder(int randevuId)
        {
            ViewBag.RandevuId = randevuId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Gonder(GeriBildirim model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.KullaniciId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            model.OlusturmaTarihi = DateTime.Now;

            _context.geriBildirims.Add(model);
            _context.SaveChanges();

            TempData["Success"] = "Geri bildiriminiz alınmıştır, teşekkür ederiz.";
            return RedirectToAction("Index");
        }
    }
}
