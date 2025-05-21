using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands
{
    public interface IRandevuCommandService
    {
        void AddRandevu(Core.Model.Randevu randevu);
        void UpdateRandevu(Core.Model.Randevu randevu);
        void DeleteRandevu(int randevuId);
    }
}
