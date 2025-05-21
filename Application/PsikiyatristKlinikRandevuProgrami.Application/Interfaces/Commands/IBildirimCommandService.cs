using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands
{
    public interface IBildirimCommandService
    {
        void AddBildirim(Core.Model.Bildirim bildirim);
        void UpdateBildirim(Core.Model.Bildirim bildirim);
        void DeleteBildirim(int bildirimId);
    }
}
