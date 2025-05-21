using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Features.Bildirim.Commands
{
    // AddBildirimCommand.cs
    using PsikiyatristKlinikRandevuProgrami.Core.Model;
    using MediatR;

    public class AddBildirimCommand : IRequest<Unit>
    {
        public Bildirim Bildirim { get; set; }

        public AddBildirimCommand(Bildirim bildirim)
        {
            Bildirim = bildirim;
        }
    }


}
