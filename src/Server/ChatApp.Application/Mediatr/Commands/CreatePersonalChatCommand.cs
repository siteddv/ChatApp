using ChatApp.Application.Dtos;
using ChatApp.Application.Interfaces;
using MediatR;

namespace ChatApp.Application.Mediatr.Commands;

public class CreatePersonalChatCommand : IRequest<ChatDto>
{
    public Guid UserId1 { get; set; }
    public Guid UserId2 { get; set; }
}

public class CreatePersonalChatCommandHandler : IRequestHandler<CreatePersonalChatCommand, ChatDto>
{
    private readonly IChatRepository _chatRepository;

    public CreatePersonalChatCommandHandler(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public async Task<ChatDto> Handle(CreatePersonalChatCommand command, CancellationToken cancellationToken)
    {
        var chat = await _chatRepository.CreateAsync(command);
        return new ChatDto
        {
            Id = chat.Id,
            Type = chat.Type,
            GroupId = chat.GroupId,
            Participants = new List<UserDto>()
        };
    }
}