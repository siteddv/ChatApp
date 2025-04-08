using ChatApp.Application.Dtos;
using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using MediatR;

namespace ChatApp.Application.Mediatr.Commands;

public class CreateUserCommand : IRequest<UserDto>
{
    public string Nickname { get; set; } = string.Empty;
}

public class CreateUserCommandHandler(IChatDbContext context) : IRequestHandler<CreateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Nickname = request.Nickname,
            CreatedAt = DateTime.Now
        };
        
        context.Users.Add(user);
        await context.SaveChangesAsync(cancellationToken);
        
        return new UserDto { Id = user.Id, Nickname = user.Nickname };
    }
}