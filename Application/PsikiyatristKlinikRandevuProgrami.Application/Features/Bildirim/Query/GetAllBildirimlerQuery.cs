using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsikiyatristKlinikRandevuProgrami.Application.Features.Bildirim.Query
{
    public class GetAllBildirimlerQuery : IRequest<List<Core.Model.Bildirim>>
    {
    }
}
