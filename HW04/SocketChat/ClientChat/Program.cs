using Microsoft.AspNetCore.SignalR.Client;
using SocketChat.Common.Entities;
namespace ClientChat
{
    internal class Program
    {
        static HubConnection HubConnection;
        async static Task Main(string[] args)
        {
            Console.Write("Введите ваше имя: ");
            string name = Console.ReadLine();
            HubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7217/chat")
                .Build();
            HubConnection.On<SignalRMessage>("Send", signalRMessage => Print($"{signalRMessage.FromUser}: {signalRMessage.Message}"));
            await HubConnection.StartAsync();
            bool isRun = true;
            while (isRun)
            {
                var message = Console.ReadLine();
                SignalRMessage signalRMessage = new SignalRMessage();
                signalRMessage.Message = message;
                signalRMessage.FromUser = name;
                if (message != "exit")
                {
                    await HubConnection.SendAsync("Send", signalRMessage);
                }
                else
                {
                    isRun = false;
                }

            }
        }
        static void Print(string message)
        {
            var ct = Console.CursorTop;
            var cl = Console.CursorLeft;
            Console.MoveBufferArea(0,ct,cl,1,0,ct+1);
            Console.CursorLeft = 0;
            Console.CursorTop = ct;
            Console.WriteLine(message);
            //Console.CursorTop = ct+1;
            Console.CursorLeft = cl;

     }
    }
}
