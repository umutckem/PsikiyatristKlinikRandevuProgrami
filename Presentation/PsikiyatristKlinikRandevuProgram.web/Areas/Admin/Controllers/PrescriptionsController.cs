using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Application.Recete.Queries;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services; // CommandInvoker
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.DeleteCommand; // DeleteReceteCommand
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PrescriptionsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IReceteQueryService _receteQueryService;
        private readonly IReceteCommandService _receteCommandService;
        private readonly CommandInvoker _commandInvoker;

        public PrescriptionsController(
            IMediator mediator,
            IReceteQueryService receteQueryService,
            IReceteCommandService receteCommandService,
            CommandInvoker commandInvoker)
        {
            _mediator = mediator;
            _receteQueryService = receteQueryService;
            _receteCommandService = receteCommandService;
            _commandInvoker = commandInvoker;
        }

        public async Task<IActionResult> Index(Guid id)
        {
            var receteler = await _mediator.Send(new GetAllRecetelerQuery());
            var kullaniciReceteleri = receteler.Where(x => x.HastaId == id);
            return View(kullaniciReceteleri);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recete = _receteQueryService.GetAllReceteler()
                                            .FirstOrDefault(x => x.Id == id);

            if (recete is not null)
            {
                var deleteCommand = new DeleteReceteCommand(_receteCommandService, id);
                _commandInvoker.ExecuteCommand(deleteCommand);
                TempData["Message"] = "Reçete başarıyla silindi.";
            }

            return RedirectToAction("Index", "User", new { area = "Admin" });
        }
    }
}
