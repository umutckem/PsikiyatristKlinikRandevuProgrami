using MediatR;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System.Collections.Generic;

namespace PsikiyatristKlinikRandevuProgrami.Application.Randevu.Queries
{
    public class GetAllRandevularQuery : IRequest<List<Core.Model.Randevu>>
    {
        // Parametre almadan tüm randevuları getirir
    }
}
