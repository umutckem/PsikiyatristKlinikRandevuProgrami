using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Queries;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services
{
    public class KullaniciServiceAdapter : IKullaniciService
    {
        private readonly IKullaniciCommandService _commandService;
        private readonly IKullaniciQueryService _queryService;

        public KullaniciServiceAdapter(IKullaniciCommandService commandService, IKullaniciQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        public async Task<List<Core.Model.Kullanici>> kullanicis()
        {
            return await _queryService.GetAllKullanicilar();
        }

        public void addKullanici(Core.Model.Kullanici kullanici)
        {
            _commandService.AddKullanici(kullanici);
        }

        public void updateKullanici(Core.Model.Kullanici kullanici)
        {
            _commandService.UpdateKullanici(kullanici);
        }

        public void deleteKullanici(int kullaniciId)
        {
            _commandService.DeleteKullanici(kullaniciId);
        }
    }
}
