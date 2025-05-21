using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Interfaces
{
    public interface ICommandFacade
    {
        // Kullanıcı işlemleri
        void AddKullanici(Core.Model.Kullanici kullanici);
        void UpdateKullanici(Core.Model.Kullanici kullanici);
        void DeleteKullanici(int kullaniciId);

        // Ödeme işlemleri
        void AddOdeme(Core.Model.Odeme odeme);
        void UpdateOdeme(Core.Model.Odeme odeme);
        void DeleteOdeme(int odemeId);

        // Randevu işlemleri
        void AddRandevu(Core.Model.Randevu randevu);
        void UpdateRandevu(Core.Model.Randevu randevu);
        void DeleteRandevu(int randevuId);

        // Klinik rapor işlemleri
        void AddKlinikRapor(Core.Model.KlinikRapor klinikRapor);
        void UpdateKlinikRapor(Core.Model.KlinikRapor klinikRapor);
        void DeleteKlinikRapor(int klinikRaporId);

        // Reçete işlemleri
        void AddRecete(Core.Model.Recete recete);
        void UpdateRecete(Core.Model.Recete recete);
        void DeleteRecete(int receteId);

        // Geri bildirim işlemleri
        void AddGeriBildirim(Core.Model.GeriBildirim geriBildirim);
        void UpdateGeriBildirim(Core.Model.GeriBildirim geriBildirim);
        void DeleteGeriBildirim(int geriBildirimId);
    }
}
