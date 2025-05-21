using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Features.Bildirim.Handlers
{
    // AddBildirimCommandHandler.cs
    using MediatR;
    using PsikiyatristKlinikRandevuProgrami.Application.Features.Bildirim.Commands;
    using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;

    public class AddBildirimCommandHandler : IRequestHandler<AddBildirimCommand, Unit>
    {
        private readonly IBildirimCommandService _service;

        public AddBildirimCommandHandler(IBildirimCommandService service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(AddBildirimCommand request, CancellationToken cancellationToken)
        {
            _service.AddBildirim(request.Bildirim);
            return Unit.Value;
        }
    }


}
