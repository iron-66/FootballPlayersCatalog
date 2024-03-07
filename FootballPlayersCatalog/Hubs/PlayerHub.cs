using Microsoft.AspNetCore.SignalR;

namespace FootballPlayersCatalog.Hubs
{
    public class PlayerHub : Hub
    {
        public async Task SendPlayerUpdate(string message)
        {
            await Clients.All.SendAsync("ReceivePlayerUpdate", message);
        }
    }
}

