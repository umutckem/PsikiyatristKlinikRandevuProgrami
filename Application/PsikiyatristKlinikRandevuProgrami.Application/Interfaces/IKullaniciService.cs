using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Interfaces
{
    public interface IKullaniciService
    {
        Task<List<Core.Model.Kullanici>> kullanicis();
        void addKullanici(Core.Model.Kullanici kullanici);
        void updateKullanici(Core.Model.Kullanici kullanici);
        void deleteKullanici(int kullaniciId);
    }
}
