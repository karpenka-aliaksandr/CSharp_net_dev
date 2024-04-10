using Microsoft.AspNetCore.SignalR;
using SocketChat.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketChat.BLL.Logic
{
    public class ChatHub : Hub
    {
        public async Task Send(SignalRMessage signalRMessage)
        {
            await Clients.Others.SendAsync("Send", signalRMessage);
        }

        public async Task SendToUser(SignalRMessage signalRMessage)
        {
            var client = Clients.Client(signalRMessage.ConnectionId);
            await client.SendAsync($"message: {signalRMessage.Message}. From user: {signalRMessage.FromUser}");
        }

        

    }
}
