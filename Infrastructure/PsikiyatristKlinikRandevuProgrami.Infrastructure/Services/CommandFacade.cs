using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using PsikiyatristKlinikRandevuProgrami.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services
{
    public class CommandFacade : ICommandFacade
    {
        private readonly ApplicationDbContext _context;

        public CommandFacade(ApplicationDbContext context)
        {
            _context = context;
        }

        // Kullanici işlemleri
        public void AddKullanici(Core.Model.Kullanici kullanici)
        {
            _context.kullanicis.Add(kullanici);
            _context.SaveChanges();
        }

        public void UpdateKullanici(Core.Model.Kullanici kullanici)
        {
            _context.kullanicis.Update(kullanici);
            _context.SaveChanges();
        }

        public void DeleteKullanici(int kullaniciId)
        {
            var entity = _context.kullanicis.Find(kullaniciId);
            if (entity != null)
            {
                _context.kullanicis.Remove(entity);
                _context.SaveChanges();
            }
        }

        // Odeme işlemleri
        public void AddOdeme(Core.Model.Odeme odeme)
        {
            _context.odemes.Add(odeme);
            _context.SaveChanges();
        }

        public void UpdateOdeme(Core.Model.Odeme odeme)
        {
            _context.odemes.Update(odeme);
            _context.SaveChanges();
        }

        public void DeleteOdeme(int odemeId)
        {
            var entity = _context.odemes.Find(odemeId);
            if (entity != null)
            {
                _context.odemes.Remove(entity);
                _context.SaveChanges();
            }
        }

        // Randevu işlemleri
        public void AddRandevu(Core.Model.Randevu randevu)
        {
            _context.randevus.Add(randevu);
            _context.SaveChanges();
        }

        public void UpdateRandevu(Core.Model.Randevu randevu)
        {
            _context.randevus.Update(randevu);
            _context.SaveChanges();
        }

        public void DeleteRandevu(int randevuId)
        {
            var entity = _context.randevus.Find(randevuId);
            if (entity != null)
            {
                _context.randevus.Remove(entity);
                _context.SaveChanges();
            }
        }

        // Klinik Rapor işlemleri
        public void AddKlinikRapor(Core.Model.KlinikRapor klinikRapor)
        {
            _context.klinikRapors.Add(klinikRapor);
            _context.SaveChanges();
        }

        public void UpdateKlinikRapor(Core.Model.KlinikRapor klinikRapor)
        {
            _context.klinikRapors.Update(klinikRapor);
            _context.SaveChanges();
        }

        public void DeleteKlinikRapor(int klinikRaporId)
        {
            var entity = _context.klinikRapors.Find(klinikRaporId);
            if (entity != null)
            {
                _context.klinikRapors.Remove(entity);
                _context.SaveChanges();
            }
        }

        // Recete işlemleri
        public void AddRecete(Core.Model.Recete recete)
        {
            _context.recetes.Add(recete);
            _context.SaveChanges();
        }

        public void UpdateRecete(Core.Model.Recete recete)
        {
            _context.recetes.Update(recete);
            _context.SaveChanges();
        }

        public void DeleteRecete(int receteId)
        {
            var entity = _context.recetes.Find(receteId);
            if (entity != null)
            {
                _context.recetes.Remove(entity);
                _context.SaveChanges();
            }
        }

        // Geri Bildirim işlemleri
        public void AddGeriBildirim(Core.Model.GeriBildirim geriBildirim)
        {
            _context.geriBildirims.Add(geriBildirim);
            _context.SaveChanges();
        }

        public void UpdateGeriBildirim(Core.Model.GeriBildirim geriBildirim)
        {
            _context.geriBildirims.Update(geriBildirim);
            _context.SaveChanges();
        }

        public void DeleteGeriBildirim(int geriBildirimId)
        {
            var entity = _context.geriBildirims.Find(geriBildirimId);
            if (entity != null)
            {
                _context.geriBildirims.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
