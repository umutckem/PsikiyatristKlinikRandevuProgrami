using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Interfaces
{
    public interface IGeriBildirimCommandService
    {
        void AddGeriBildirim(GeriBildirim geriBildirim);
        void UpdateGeriBildirim(GeriBildirim geriBildirim);
        void DeleteGeriBildirim(int geriBildirimId);

    }
}
