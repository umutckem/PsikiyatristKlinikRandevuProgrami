using Microsoft.AspNetCore.SignalR;

namespace PsikiyatristKlinikRandevuProgrami.Web.Hubs
{
    public class AppointmentHub : Hub
    {
        public async Task SendAppointmentNotification(string doctorUserId, string message)
        {
            await Clients.User(doctorUserId).SendAsync("ReceiveAppointmentNotification", message);
        }
    }
}