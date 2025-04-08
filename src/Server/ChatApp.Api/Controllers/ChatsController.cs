using ChatApp.Application.Mediatr.Commands;
using ChatApp.Application.Mediatr.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatsController(IMediator mediator) : ControllerBase
{
    [HttpPost("personal")]
    public async Task<IActionResult> CreatePersonalChat([FromBody] CreatePersonalChatCommand command)
    {
        var chat = await mediator.Send(command);
        return Ok(chat);
    }

    [HttpGet("{id}/messages")]
    public async Task<IActionResult> GetChatMessages(Guid id)
    {
        var query = new GetChatMessagesQuery { ChatId = id };
        var messages = await mediator.Send(query);
        return Ok(messages);
    }
}