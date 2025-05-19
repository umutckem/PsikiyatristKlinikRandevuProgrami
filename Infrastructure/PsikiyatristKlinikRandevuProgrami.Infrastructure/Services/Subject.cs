using PsikiyatristKlinikRandevuProgrami.Application.Interfaces;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Infrastructure.Services
{
    public class Subject : ISubject
    {
        private List<IObserver> _observers = new();

        public void Attach(IObserver observer) => _observers.Add(observer);
        public void Detach(IObserver observer) => _observers.Remove(observer);

        public void Notify(Bildirim bildirim)
        {
            foreach (var observer in _observers)
            {
                observer.Update(bildirim);
            }
        }
    }
}
