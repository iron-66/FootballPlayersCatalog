using Microsoft.AspNetCore.SignalR;

namespace FootballPlayersCatalog.Hubs
{
    /// <summary>
    /// Хаб SignalR для обновления данных игроков
    /// </summary>
    public class PlayerHub : Hub
    {
        /// <summary>
        /// Отправляет сообщение об обновлении данных игрока
        /// </summary>
        /// <param name="message">Сообщение об обновлении данных</param>
        public async Task SendPlayerUpdate(string message)
        {
            await Clients.All.SendAsync("ReceivePlayerUpdate", message);
        }
    }
}
