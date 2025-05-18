using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services
{
    public class BildirimSubject : ISubject
    {
        private readonly List<IObserver> _observers = new();

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }

        // Yeni bildirim geldiğinde çağırılacak metot
        public void YeniBildirimGeldi(string mesaj)
        {
            // Bildirimi notify ile gözlemcilere ilet
            Notify(mesaj);
        }
    }
}
