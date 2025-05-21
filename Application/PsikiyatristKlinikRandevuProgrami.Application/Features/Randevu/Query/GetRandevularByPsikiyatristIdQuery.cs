// Application/Randevu/Queries/GetRandevularByPsikiyatristIdQuery.cs
using MediatR;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;

namespace PsikiyatristKlinikRandevuProgrami.Application.Randevu.Queries
{
    public class GetRandevularByPsikiyatristIdQuery : IRequest<List<Core.Model.Randevu>>
    {
        public Guid PsikiyatristId { get; set; }

        public GetRandevularByPsikiyatristIdQuery(Guid psikiyatristId)
        {
            PsikiyatristId = psikiyatristId;
        }
    }
}
