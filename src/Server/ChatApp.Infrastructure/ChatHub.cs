using ChatApp.Application.Mediatr.Commands;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Infrastructure;

public class ChatHub : Hub
{
    private readonly IMediator _mediator;

    public ChatHub(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task SendMessage(Guid chatId, string content)
    {
        var command = new SendMessageCommand
        {
            SenderId = Guid.Parse(Context.User.Identity!.Name),
            Content = content,
            ChatId = chatId
        };

        var message = await _mediator.Send(command);
        await Clients.Group(chatId.ToString()).SendAsync("ReceiveMessage", message);
    }
}