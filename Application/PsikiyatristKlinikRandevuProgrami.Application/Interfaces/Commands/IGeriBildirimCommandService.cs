using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands
{
    public interface IGeriBildirimCommandService
    {
        void AddGeriBildirim(Core.Model.GeriBildirim geriBildirim);
        void UpdateGeriBildirim(Core.Model.GeriBildirim geriBildirim);
        void DeleteGeriBildirim(int geriBildirimId);

    }
}
