using Microsoft.EntityFrameworkCore;
using SocketChat.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketChat.DAL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ChatContext _chatContext;
        public MessageRepository(ChatContext chatContext)
        {
            _chatContext = chatContext;
        }

        public async Task<List<SignalRMessage>> GetMessagesAsync()
        {
            return await _chatContext.Messages.ToListAsync();
        }

        public async Task AddMessageAsync(SignalRMessage message)
        {
            await _chatContext.Messages.AddAsync(message);
            await _chatContext.SaveChangesAsync();
        }
    }
}
