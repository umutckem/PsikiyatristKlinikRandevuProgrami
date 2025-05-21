using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Application.KlinikRapor.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.KlinikRapor.Handlers
{
    public class GetAllKlinikRaporlarQueryHandler : IRequestHandler<GetAllKlinikRaporlarQuery, List<Core.Model.KlinikRapor>>
    {
        private readonly IKlinikRaporQueryService _queryService;

        public GetAllKlinikRaporlarQueryHandler(IKlinikRaporQueryService queryService)
        {
            _queryService = queryService;
        }

        public Task<List<Core.Model.KlinikRapor>> Handle(GetAllKlinikRaporlarQuery request, CancellationToken cancellationToken)
        {
            var result = _queryService.GetAllKlinikRaporlar();
            return Task.FromResult(result);
        }
    }
}
