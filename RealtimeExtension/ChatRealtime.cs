using Microsoft.AspNetCore.SignalR;

namespace ApFpoly_API.RealtimeExtension
{
    public class ChatRealtime :Hub
    {
        private int _counter = 0;

        public async Task SendMessage(string user, string message)
        {
            _counter++;
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
