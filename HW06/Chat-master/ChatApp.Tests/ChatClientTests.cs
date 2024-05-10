using ChatNetwork;
using ChatApp;

using Moq;
using CommonChat.DTO;
using System.Net;
namespace ChatApp.Tests

{
    public class ChatClientTests
    {
        [Fact]
        public void SendMessageTest()
        {
            var messageSourceMock = new Mock<IMessageSource>();
            var serverIPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            messageSourceMock.Setup(ms => ms.GetServerIPEndPoint()).Returns(serverIPEndPoint);
            string _name = "Alex";
            var chatClient = new ChatClient(_name, messageSourceMock.Object);
            var chatMessage = new ChatMessage();

            chatClient.SendMessage(chatMessage, serverIPEndPoint);

            messageSourceMock.Verify(ms => ms.SendMessage(chatMessage, serverIPEndPoint));
        }


        [Fact]
        public void RegisterTest()
        {
            var messageSourceMock = new Mock<IMessageSource>();
            var serverIPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            messageSourceMock.Setup(ms => ms.GetServerIPEndPoint()).Returns(serverIPEndPoint);
            string _name = "Alex";
            var chatClient = new ChatClient(_name, messageSourceMock.Object);
            var registerMessage = new ChatMessage() { Command = Command.Register, FromName = _name };

            chatClient.Register();

            messageSourceMock.Verify(ms => ms.SendMessage(It.IsAny<ChatMessage>(),serverIPEndPoint));
        }


        
    }
}