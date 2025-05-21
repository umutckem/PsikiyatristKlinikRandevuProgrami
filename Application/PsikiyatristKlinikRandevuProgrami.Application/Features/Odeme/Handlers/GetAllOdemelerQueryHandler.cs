using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Application.Odeme.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Odeme.Handlers
{
    public class GetAllOdemelerQueryHandler : IRequestHandler<GetAllOdemelerQuery, List<Core.Model.Odeme>>
    {
        private readonly IOdemeQueryService _queryService;

        public GetAllOdemelerQueryHandler(IOdemeQueryService queryService)
        {
            _queryService = queryService;
        }

        public Task<List<Core.Model.Odeme>> Handle(GetAllOdemelerQuery request, CancellationToken cancellationToken)
        {
            var odemeler = _queryService.GetAllOdemeler();
            return Task.FromResult(odemeler);
        }
    }
}
