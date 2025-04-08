using ChatApp.Application.Dtos;
using MediatR;

namespace ChatApp.Application.Mediatr.Commands;

public class SendMessageCommand : IRequest<MessageDto>
{
    public Guid SenderId { get; set; }
    public string Content { get; set; } = string.Empty;
    public Guid ChatId { get; set; }
}