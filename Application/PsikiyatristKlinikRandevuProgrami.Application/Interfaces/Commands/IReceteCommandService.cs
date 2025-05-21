using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Interfaces.Commands
{
    public interface IReceteCommandService
    {
        void AddRecete(Core.Model.Recete recete);
        void UpdateRecete(Core.Model.Recete recete);
        void DeleteRecete(int receteId);
    }
}
