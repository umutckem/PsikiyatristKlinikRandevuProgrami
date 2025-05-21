using MediatR;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System.Collections.Generic;

namespace PsikiyatristKlinikRandevuProgrami.Application.Kullanici.Queries
{
    public class GetAllKullanicilarQuery : IRequest<List<Core.Model.Kullanici>>
    {
        // Parametre gerektirmeyen listeleme sorgusu
    }
}
