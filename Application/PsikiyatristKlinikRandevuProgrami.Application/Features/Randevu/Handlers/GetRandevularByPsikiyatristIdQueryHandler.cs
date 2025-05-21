// Application/Randevu/Handlers/GetRandevularByPsikiyatristIdQueryHandler.cs
using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Application.Randevu.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class GetRandevularByPsikiyatristIdQueryHandler : IRequestHandler<GetRandevularByPsikiyatristIdQuery, List<Randevu>>
{
    private readonly IRandevuQueryService _queryService;

    public GetRandevularByPsikiyatristIdQueryHandler(IRandevuQueryService queryService)
    {
        _queryService = queryService;
    }

    public Task<List<Randevu>> Handle(GetRandevularByPsikiyatristIdQuery request, CancellationToken cancellationToken)
    {
        var randevular = _queryService.GetRandevularByPsikiyatristId(request.PsikiyatristId);
        return Task.FromResult(randevular);
    }
}
