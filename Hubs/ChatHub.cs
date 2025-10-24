using Microsoft.AspNetCore.SignalR;

namespace PRM392_Server.Hubs
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {

            await base.OnConnectedAsync();
        }

        public async Task SendMessage(string user, string message)
        {
            Console.WriteLine("Coming message!");
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            await Clients.Group("as").SendAsync("Coming message!");
        }
    }
}
