using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Features.Bildirim.Query;
using System.Collections.Generic;

namespace PsikiyatristKlinikRandevuProgrami.Web.Areas.Hasta.Controllers
{
    [Area("Hasta")]
    [Authorize(Roles = "Hasta")]
    public class BildirimlerController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IBildirimCommandService _bildirimCommandService;
        private readonly IBildirimQueryService _bildirimQueryServices;

        public BildirimlerController(IMediator mediator, IBildirimCommandService bildirimCommandService, IBildirimQueryService bildirimQueryServices)
        {
            _mediator = mediator;
            _bildirimCommandService = bildirimCommandService;
            _bildirimQueryServices = bildirimQueryServices;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var bildirimler = await _mediator.Send(new GetAllBildirimlerQuery());
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (!string.IsNullOrEmpty(userId) && Guid.TryParse(userId, out var parsedUserId))
                {
                    bildirimler = bildirimler.Where(b => b.AliciKullaniciId == parsedUserId).ToList();
                }
                else
                {
                    TempData["Error"] = "Kullanıcı kimliği alınamadı. Lütfen tekrar giriş yapın.";
                    return View(new List<Bildirim>());
                }

                return View(bildirimler);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Bildirimler yüklenirken hata oluştu: {ex.Message}";
                return View(new List<Bildirim>());
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var bildirim = _bildirimQueryServices.GetAllBildirimler()
                                                 .FirstOrDefault(x => x.Id == id);

            if (bildirim == null)
            {
                TempData["Error"] = "Böyle bir bildirim bulunamadı.";
                return RedirectToAction("Index");
            }

            _bildirimCommandService.DeleteBildirim(id);
            return RedirectToAction("Index");
        }

    }
}
