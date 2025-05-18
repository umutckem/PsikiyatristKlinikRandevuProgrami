using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
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

        public List<Kullanici> kullanicis()
        {
            return _queryService.GetAllKullanicilar();
        }

        public void addKullanici(Kullanici kullanici)
        {
            _commandService.AddKullanici(kullanici);
        }

        public void updateKullanici(Kullanici kullanici)
        {
            _commandService.UpdateKullanici(kullanici);
        }

        public void deleteKullanici(int kullaniciId)
        {
            _commandService.DeleteKullanici(kullaniciId);
        }
    }
}
