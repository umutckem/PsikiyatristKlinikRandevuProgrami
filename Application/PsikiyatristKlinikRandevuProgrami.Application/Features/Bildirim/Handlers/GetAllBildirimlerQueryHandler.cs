using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Features.Bildirim.Query;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Bildirim.Handlers
{
    public class GetAllBildirimlerQueryHandler : IRequestHandler<GetAllBildirimlerQuery, List<Core.Model.Bildirim>>
    {
        private readonly IBildirimQueryService _queryService;

        public GetAllBildirimlerQueryHandler(IBildirimQueryService queryService)
        {
            _queryService = queryService;
        }

        public Task<List<Core.Model.Bildirim>> Handle(GetAllBildirimlerQuery request, CancellationToken cancellationToken)
        {
            var bildirimler = _queryService.GetAllBildirimler();
            return Task.FromResult(bildirimler);
        }
    }
}
