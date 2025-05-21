using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Application.Randevu.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Randevu.Handlers
{
    public class GetAllRandevularQueryHandler : IRequestHandler<GetAllRandevularQuery, List<Core.Model.Randevu>>
    {
        private readonly IRandevuQueryService _queryService;

        public GetAllRandevularQueryHandler(IRandevuQueryService queryService)
        {
            _queryService = queryService;
        }

        public Task<List<Core.Model.Randevu>> Handle(GetAllRandevularQuery request, CancellationToken cancellationToken)
        {
            var randevular = _queryService.GetAllRandevular();
            return Task.FromResult(randevular);
        }
    }
}
