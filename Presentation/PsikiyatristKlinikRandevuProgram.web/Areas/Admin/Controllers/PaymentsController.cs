using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Odeme.Queries;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Randevu;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PaymentsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IOdemeCommandService _odemeCommandService;

        public PaymentsController(IMediator mediator, ApplicationDbContext applicationDbContext, IOdemeCommandService odemeCommandService)
        {
            _mediator = mediator;
            _applicationDbContext = applicationDbContext;
            _odemeCommandService = odemeCommandService;
        }

        public async Task<IActionResult> Index(Guid id)
        {
            var paymets = await _mediator.Send(new GetAllOdemelerQuery());
            var kullaniciOdemeleri = paymets.Where(x => x.HastaId == id).ToList();

            return View(kullaniciOdemeleri);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            if (Id != 0)
            {
                _odemeCommandService.DeleteOdeme(Id);
            }
            
            return RedirectToAction("Index", "User", new { area = "Admin" });
        }
    }
}
