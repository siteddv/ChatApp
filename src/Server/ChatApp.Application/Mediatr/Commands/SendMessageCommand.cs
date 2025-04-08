using ChatApp.Application.Dtos;
using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using MediatR;

namespace ChatApp.Application.Mediatr.Commands;

public class SendMessageCommand : IRequest<MessageDto>
{
    public Guid SenderId { get; set; }
    public string Content { get; set; } = string.Empty;
    public Guid ChatId { get; set; }
}

public class SendMessageCommandHandler(IChatDbContext chatDbContext) : IRequestHandler<SendMessageCommand, MessageDto>
{
    public async Task<MessageDto> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        var message = new Message()
        {
            Id = Guid.NewGuid(),
            Content = request.Content,
            CreatedAt = DateTime.Now,
            SenderId = request.SenderId,
            ChatId = request.ChatId
        };
        
        chatDbContext.Messages.Add(message);
        await chatDbContext.SaveChangesAsync(cancellationToken);
        
        return new MessageDto
        {
            Id = message.Id, 
            Content = message.Content,
            ChatId = message.ChatId,
            CreatedAt = message.CreatedAt,
            Sender = new UserDto
            {
                Id = message.SenderId, 
                Nickname = message.Sender.Nickname
            }
        };
    }
}