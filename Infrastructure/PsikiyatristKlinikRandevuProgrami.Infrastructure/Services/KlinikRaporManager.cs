using Microsoft.Extensions.DependencyInjection;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.KlinikRapor
{
    public sealed class KlinikRaporManager
    {
        private static KlinikRaporManager _instance;
        private static readonly object _lock = new();

        private IServiceProvider _serviceProvider;

        private KlinikRaporManager() { }

        public static KlinikRaporManager Instance
        {
            get
            {
                lock (_lock)
                {
                    return _instance ??= new KlinikRaporManager();
                }
            }
        }

        public void Configure(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void RaporEkle(Guid hastaId, Guid psikiyatristId, string raporIcerigi)
        {
            if (_serviceProvider == null)
                throw new InvalidOperationException("KlinikRaporManager yapılandırılmadan kullanılamaz.");

            using var scope = _serviceProvider.CreateScope();
            var commandService = scope.ServiceProvider.GetRequiredService<IKlinikRaporCommandService>();

            var rapor = new Core.Model.KlinikRapor
            {
                HastaId = hastaId,
                PsikiyatristId = psikiyatristId,
                RaporIcerigi = raporIcerigi,
                OlusturmaTarihi = DateTime.Now
            };

            commandService.AddKlinikRapor(rapor);
        }

        public void SilRapor(int raporId)
        {
            if (_serviceProvider == null)
                throw new InvalidOperationException("KlinikRaporManager yapılandırılmadan kullanılamaz.");

            using var scope = _serviceProvider.CreateScope();
            var commandService = scope.ServiceProvider.GetRequiredService<IKlinikRaporCommandService>();

            commandService.DeleteKlinikRapor(raporId);
        }
    }
}
