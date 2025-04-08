using ChatApp.Application.Interfaces;
using ChatApp.Application.Mediatr.Commands;
using ChatApp.Domain.Common.Enums;
using ChatApp.Domain.Entities;
using ChatApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly ChatDbContext _context;

    public async Task<Chat> CreateAsync(CreatePersonalChatCommand command)
    {
        var chat = new Chat { Type = ChatType.Personal };
        await _context.Chats.AddAsync(chat);
        await _context.SaveChangesAsync();
        return chat;
    }

    public async Task<IEnumerable<Message>> GetMessagesByChatIdAsync(Guid chatId)
    {
        return await _context.Messages
            .Where(m => m.ChatId == chatId)
            .ToListAsync();
    }
}