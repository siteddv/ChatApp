using ChatApp.Application.Dtos;
using MediatR;

namespace ChatApp.Application.Mediatr.Queries;

public class GetChatMessagesQuery : IRequest<IEnumerable<MessageDto>>
{
    public Guid ChatId { get; set; }
}

public class GetChatMessagesQueryHandler : IRequestHandler<GetChatMessagesQuery, IEnumerable<MessageDto>>