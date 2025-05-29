using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Odeme.Queries;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgram.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PaymentsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _applicationDbContext;

        public PaymentsController(IMediator mediator, ApplicationDbContext applicationDbContext)
        {
            _mediator = mediator;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IActionResult> Index(Guid id)
        {
            var paymets = await _mediator.Send(new GetAllOdemelerQuery());
            var kullaniciOdemeleri = paymets.Where(x => x.HastaId == id);

            return View();
        }
    }
}
