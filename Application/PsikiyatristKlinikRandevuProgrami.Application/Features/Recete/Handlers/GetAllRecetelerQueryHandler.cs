using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Application.Recete.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Recete.Handlers
{
    public class GetAllRecetelerQueryHandler : IRequestHandler<GetAllRecetelerQuery, List<Core.Model.Recete>>
    {
        private readonly IReceteQueryService _queryService;

        public GetAllRecetelerQueryHandler(IReceteQueryService queryService)
        {
            _queryService = queryService;
        }

        public Task<List<Core.Model.Recete>> Handle(GetAllRecetelerQuery request, CancellationToken cancellationToken)
        {
            var receteler = _queryService.GetAllReceteler();
            return Task.FromResult(receteler);
        }
    }
}
