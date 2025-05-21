using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.UpdateCommand
{
    public class UpdateKullaniciCommand
    {
        private readonly IKullaniciCommandService _commandService;
        private readonly Core.Model.Kullanici _kullanici;

        public UpdateKullaniciCommand(IKullaniciCommandService commandService, Core.Model.Kullanici kullanici)
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
