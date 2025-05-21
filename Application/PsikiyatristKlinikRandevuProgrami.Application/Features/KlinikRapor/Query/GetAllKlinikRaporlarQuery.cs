using MediatR;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System.Collections.Generic;

namespace PsikiyatristKlinikRandevuProgrami.Application.KlinikRapor.Queries
{
    public class GetAllKlinikRaporlarQuery : IRequest<List<Core.Model.KlinikRapor>>
    {
        // Bu sorgu parametre almadığı için içi boş.
        // Gerekirse filtreleme için parametreler eklenebilir.
    }
}
