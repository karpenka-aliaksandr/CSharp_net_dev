using SocketChat.Common.Entities;
using SocketChat.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketChat.BLL.Logic
{
    public class MessageLogic : IMessageLogic
    {
        private readonly IMessageRepository _messageRepository;
        public MessageLogic(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task AddAsync(SignalRMessage message)
        {
            await _messageRepository.AddMessageAsync(message);
        }

        public async Task<List<SignalRMessage>> GetAllAsync()
        {
            return await _messageRepository.GetMessagesAsync();
        }
    }
}
