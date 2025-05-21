using PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services.Command.DeleteCommand
{
    public class DeleteKullaniciCommand
    {
        private readonly IKullaniciCommandService _commandService;
        private readonly int _kullaniciId;

        public DeleteKullaniciCommand(IKullaniciCommandService commandService, int kullaniciId)
        {
            _commandService = commandService;
            _kullaniciId = kullaniciId;
        }

        public void Execute()
        {
            _commandService.DeleteKullanici(_kullaniciId);
        }
    }
}
