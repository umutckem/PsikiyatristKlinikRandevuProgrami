using MediatR;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System.Collections.Generic;

namespace PsikiyatristKlinikRandevuProgrami.Application.Odeme.Queries
{
    public class GetAllOdemelerQuery : IRequest<List<Core.Model.Odeme>>
    {
        // Parametre almadan tüm ödemeleri getirir
    }
}
