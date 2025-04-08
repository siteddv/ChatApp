using ChatApp.Application.Dtos;

namespace ChatApp.Application.Interfaces;

public interface IChatRepository
{
    Task<ChatDto> CreateAsync(ChatDto command);
    Task<IEnumerable<MessageDto>> GetMessagesByChatIdAsync(Guid chatId);
}