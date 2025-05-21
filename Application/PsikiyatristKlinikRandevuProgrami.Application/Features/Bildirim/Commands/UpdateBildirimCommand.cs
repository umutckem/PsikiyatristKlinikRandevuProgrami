using MediatR;
using PsikiyatristKlinikRandevuProgrami.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Features.Bildirim.Commands
{
    using PsikiyatristKlinikRandevuProgrami.Core.Model;
    using MediatR;
    // UpdateBildirimCommand.cs
    public class UpdateBildirimCommand : IRequest<Unit>
    {
        public Bildirim Bildirim { get; set; }

        public UpdateBildirimCommand(Bildirim bildirim)
        {
            Bildirim = bildirim;
        }
    }

}
