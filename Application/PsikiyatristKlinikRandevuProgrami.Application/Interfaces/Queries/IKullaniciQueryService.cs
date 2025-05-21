using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries
{
    public interface IKullaniciQueryService
    {
        Task<List<Core.Model.Kullanici>> GetAllKullanicilar();
    }
}
