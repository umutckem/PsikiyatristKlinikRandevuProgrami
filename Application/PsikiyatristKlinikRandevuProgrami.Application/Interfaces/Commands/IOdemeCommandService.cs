using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands
{
    public interface IOdemeCommandService
    {
        void AddOdeme(Core.Model.Odeme odeme);
        void UpdateOdeme(Core.Model.Odeme odeme);
        void DeleteOdeme(int odemeId);
    }
}
