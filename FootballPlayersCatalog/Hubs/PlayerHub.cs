using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

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

