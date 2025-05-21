using MediatR;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System.Collections.Generic;

namespace PsikiyatristKlinikRandevuProgrami.Application.GeriBildirim.Queries
{
    public class GetAllGeriBildirimsQuery : IRequest<List<Core.Model.GeriBildirim>>
    {
    }
}
