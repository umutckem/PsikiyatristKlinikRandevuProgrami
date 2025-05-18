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
        void AddKullanici(Kullanici kullanici);
        void UpdateKullanici(Kullanici kullanici);
        void DeleteKullanici(int kullaniciId);

        // Ödeme işlemleri
        void AddOdeme(Odeme odeme);
        void UpdateOdeme(Odeme odeme);
        void DeleteOdeme(int odemeId);

        // Randevu işlemleri
        void AddRandevu(Randevu randevu);
        void UpdateRandevu(Randevu randevu);
        void DeleteRandevu(int randevuId);

        // Klinik rapor işlemleri
        void AddKlinikRapor(KlinikRapor klinikRapor);
        void UpdateKlinikRapor(KlinikRapor klinikRapor);
        void DeleteKlinikRapor(int klinikRaporId);

        // Reçete işlemleri
        void AddRecete(Recete recete);
        void UpdateRecete(Recete recete);
        void DeleteRecete(int receteId);

        // Geri bildirim işlemleri
        void AddGeriBildirim(GeriBildirim geriBildirim);
        void UpdateGeriBildirim(GeriBildirim geriBildirim);
        void DeleteGeriBildirim(int geriBildirimId);
    }
}
