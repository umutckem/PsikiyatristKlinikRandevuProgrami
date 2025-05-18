using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services
{
    public class UpdateKullaniciCommand
    {
        private readonly IKullaniciCommandService _commandService;
        private readonly Kullanici _kullanici;

        public UpdateKullaniciCommand(IKullaniciCommandService commandService, Kullanici kullanici)
        {
            _commandService = commandService;
            _kullanici = kullanici;
        }

        public void Execute()
        {
            _commandService.UpdateKullanici(_kullanici);
        }
    }
}
