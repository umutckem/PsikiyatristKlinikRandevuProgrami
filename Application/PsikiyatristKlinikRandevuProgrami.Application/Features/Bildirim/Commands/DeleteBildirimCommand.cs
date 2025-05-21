using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Features.Bildirim.Commands
{
    public class DeleteBildirimCommand : IRequest<Unit>
    {
        public int BildirimId { get; set; }

        public DeleteBildirimCommand(int bildirimId)
        {
            BildirimId = bildirimId;
        }
    }
}
