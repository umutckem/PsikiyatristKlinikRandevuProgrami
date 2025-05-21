using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.AddCommand
{
    public class AddKullaniciCommand
    {
        private readonly IKullaniciCommandService _commandService;
        private readonly Core.Model.Kullanici _kullanici;

        public AddKullaniciCommand(IKullaniciCommandService commandService, Core.Model.Kullanici kullanici)
        {
            _commandService = commandService;
            _kullanici = kullanici;
        }

        public void Execute()
        {
            _commandService.AddKullanici(_kullanici);
        }
    }
}
