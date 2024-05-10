﻿using CommonChat.DTO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatNetwork
{
    public class MessageSource : IMessageSource
    {
        public UdpClient _udpClient;
        private IPEndPoint _serverEndPoint;
        
        //for Client
        public MessageSource(string ipAddress, int portServer)
        {
            _udpClient = new UdpClient();
            _serverEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), portServer);
        }

        //for Server
        public MessageSource(int portServer)
        {
            _udpClient = new UdpClient(portServer);
        }

        public IPEndPoint CreateNewIPEndPoint()
        {
            return new IPEndPoint(IPAddress.Any, 0);
        }

        public IPEndPoint GetServerIPEndPoint()
        { 
           return new IPEndPoint(_serverEndPoint.Address, _serverEndPoint.Port); 
        } 
        
        public ChatMessage Receive(ref IPEndPoint ipEndPoint)
        {
            byte[] data = _udpClient.Receive(ref ipEndPoint);
            string jsonMessage = Encoding.UTF8.GetString(data);
            return ChatMessage.FromJson(jsonMessage);
        }


        public void SendMessage(ChatMessage chatMessage, IPEndPoint ipEndPoint)
        {
            byte[] data = Encoding.UTF8.GetBytes(chatMessage.ToJson());
            _udpClient.Send(data, data.Length, ipEndPoint);
        }
    }
}