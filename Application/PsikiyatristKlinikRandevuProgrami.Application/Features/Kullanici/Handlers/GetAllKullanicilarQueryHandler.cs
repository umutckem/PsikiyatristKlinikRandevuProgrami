using MediatR;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Application.Kullanici.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Kullanici.Handlers
{
    public class GetAllKullanicilarQueryHandler : IRequestHandler<GetAllKullanicilarQuery, List<Core.Model.Kullanici>>
    {
        private readonly IKullaniciQueryService _queryService;

        public GetAllKullanicilarQueryHandler(IKullaniciQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<List<Core.Model.Kullanici>> Handle(GetAllKullanicilarQuery request, CancellationToken cancellationToken)
        {
            return await _queryService.GetAllKullanicilar();
        }
    }
}
