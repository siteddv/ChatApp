using ChatApp.Application.Dtos;
using ChatApp.Application.Interfaces;
using ChatApp.Domain.Common.Enums;
using ChatApp.Domain.Entities;
using MediatR;

namespace ChatApp.Application.Mediatr.Commands;

public class CreatePersonalChatCommand : IRequest<ChatDto>
{
    public Guid UserId1 { get; set; }
    public Guid UserId2 { get; set; }
}

public class CreatePersonalChatCommandHandler(IChatDbContext context)
    : IRequestHandler<CreatePersonalChatCommand, ChatDto>
{
    public async Task<ChatDto> Handle(CreatePersonalChatCommand command, CancellationToken cancellationToken)
    {
        var chat = new Chat
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.Now,
            Type = ChatType.Personal
        };
        await context.Chats.AddAsync(chat, cancellationToken).ConfigureAwait(false);

        var chatUsers = new List<ChatUser>()
        {
            new()
            {
                ChatId = chat.Id,
                UserId = command.UserId1
            },
            new()
            {
                ChatId = chat.Id,
                UserId = command.UserId2
            }
        };
        
        await context.ChatUsers.AddRangeAsync(chatUsers, cancellationToken).ConfigureAwait(false);
        await context.SaveChangesAsync(cancellationToken);
        
        return new ChatDto { Id = chat.Id, Type = chat.Type };
    }
}