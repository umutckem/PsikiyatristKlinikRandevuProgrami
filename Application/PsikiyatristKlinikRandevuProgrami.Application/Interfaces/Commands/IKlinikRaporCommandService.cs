using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands
{
    public interface IKlinikRaporCommandService
    {
        void AddKlinikRapor(Core.Model.KlinikRapor klinikRapor);
        void UpdateKlinikRapor(Core.Model.KlinikRapor klinikRapor);
        void DeleteKlinikRapor(int klinikRaporId);
    }
}
