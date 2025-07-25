﻿using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Interfaces
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify(Core.Model.Bildirim bildirim);
    }
}
