using MediatR;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System.Collections.Generic;

namespace PsikiyatristKlinikRandevuProgrami.Application.Recete.Queries
{
    public class GetAllRecetelerQuery : IRequest<List<Core.Model.Recete>>
    {
        // Parametresiz, tüm reçeteleri getirir
    }
}
