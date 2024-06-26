﻿using Microsoft.EntityFrameworkCore;
using SocketChat.Common.Entities;
using System.Diagnostics.Metrics;

namespace SocketChat.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ChatContext _chatContext;
        public UserRepository(ChatContext chatContext)
        {
            _chatContext = chatContext;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _chatContext.Users.ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _chatContext.Users.AddAsync(user);
            await _chatContext.SaveChangesAsync();
        }

        /*
public static List<User> GetAll()
{
   return users;
}

public static void AddUser(User user)
{
   users.Add(user);
}
*/

    }
}
