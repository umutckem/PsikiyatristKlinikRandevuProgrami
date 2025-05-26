using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Features.Bildirim.Query;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Web.Areas.Hasta.Controllers
{
    [Area("Hasta")]
    [Authorize(Roles = "Hasta")]
    public class BildirimlerController : Controller
    {
        private readonly IMediator _mediator;

        public BildirimlerController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET: Hasta/Bildirimler/Index
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
    }
}