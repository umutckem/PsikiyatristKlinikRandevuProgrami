using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Application.GeriBildirim.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.GeriBildirim.Handlers
{
    public class GetAllGeriBildirimsQueryHandler : IRequestHandler<GetAllGeriBildirimsQuery, List<Core.Model.GeriBildirim>>
    {
        private readonly IGeriBildirimQueryService _queryService;

        public GetAllGeriBildirimsQueryHandler(IGeriBildirimQueryService queryService)
        {
            _queryService = queryService;
        }

        public Task<List<Core.Model.GeriBildirim>> Handle(GetAllGeriBildirimsQuery request, CancellationToken cancellationToken)
        {
            var result = _queryService.GetAllGeriBildirims();
            return Task.FromResult(result);
        }
    }
}
