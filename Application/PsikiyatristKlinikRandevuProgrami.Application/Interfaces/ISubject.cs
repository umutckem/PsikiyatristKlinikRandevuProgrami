using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Interfaces
{
    public interface ISubject
    {
        void Attach(IObserver observer);   // Gözlemci ekle
        void Detach(IObserver observer);   // Gözlemci çıkar
        void Notify(string message);       // Gözlemcilere bildirim gönder
    }
}
