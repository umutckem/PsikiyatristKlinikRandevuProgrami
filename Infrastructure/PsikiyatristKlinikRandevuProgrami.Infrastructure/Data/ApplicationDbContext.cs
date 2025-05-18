using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Kullanici> kullanicis { get; set; }
        public DbSet<Randevu> randevus { get; set; }
        public DbSet<Recete> recetes { get; set; }
        public DbSet<Bildirim> bildirims { get; set; }
        public DbSet<KlinikRapor> klinikRapors { get; set; }
        public DbSet<GeriBildirim> geriBildirims { get; set; }
        public DbSet<Odeme> odemes { get; set; }

        public DbSet<BildirimLog> bildirimLogs { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
