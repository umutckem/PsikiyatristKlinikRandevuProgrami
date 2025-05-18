using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Interfaces
{
    public interface IOdemeCommandService
    {
        void AddOdeme(Odeme odeme);
        void UpdateOdeme(Odeme odeme);
        void DeleteOdeme(int odemeId);
    }
}
