using Microsoft.AspNetCore.SignalR;

namespace PsikiyatristKlinikRandevuProgrami.Web.Hubs
{
    public class AppointmentHub : Hub
    {
        public async Task SendAppointmentNotification(string doctorUserId, string message)
        {
            await Clients.User(doctorUserId).SendAsync("ReceiveAppointmentNotification", message);
        }

        public async Task SendApprovalNotification(string hastaUserId, string message)
        {
            await Clients.User(hastaUserId).SendAsync("ReceiveApprovalNotification", message);
        }
        public async Task SendDeletionNotification(string hastaUserId, string message)
        {
            await Clients.User(hastaUserId).SendAsync("ReceiveDeletionNotification", message);
        }
    }
}