using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsikiyatristKlinikRandevuProgrami.Application.Kullanici.Queries;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Doktor.Controllers
{
    [Area("Doktor")]
    [Authorize(Roles = "Doktor")]
    public class HastaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;

        public HastaController(IMediator mediator , ApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Tüm Kullanici kayıtlarını al (Application katmanındaki query döndürmeli)
            var tumKullanicilar = await _mediator.Send(new GetAllKullanicilarQuery());

            // Identity tablosundaki bu RoleId’ye sahip kullanıcıları al
            var hedefRolId = "08ac6e6a-0600-4caf-8a80-5f9598f4de90";
            var identityKullanicilarIds = await _context.UserRoles
                .Where(ur => ur.RoleId == hedefRolId)
                .Select(ur => ur.UserId)
                .ToListAsync();

            // IdentityUserId eşleşmesi ile filtrele
            var filtrelenmisKullanicilar = tumKullanicilar
                .Where(k => identityKullanicilarIds.Contains(k.IdentityUserId))
                .ToList();

            return View(filtrelenmisKullanicilar);
        }



    }
}
