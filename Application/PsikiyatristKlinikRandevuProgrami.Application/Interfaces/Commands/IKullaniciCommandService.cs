using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands
{
    public interface IKullaniciCommandService
    {
        Task AddKullanici(Core.Model.Kullanici kullanici);
        Task UpdateKullanici(Core.Model.Kullanici kullanici);
        Task DeleteKullanici(int kullaniciId);
    }
}
