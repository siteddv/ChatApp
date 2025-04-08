using ChatApp.Application.Dtos;
using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using MediatR;

namespace ChatApp.Application.Mediatr.Commands;

public class CreateUserCommand : IRequest<UserDto>
{
    public string Nickname { get; set; } = string.Empty;
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new UserDto() { Nickname = request.Nickname };
        await _userRepository.AddAsync(user);
        return new UserDto { Id = user.Id, Nickname = user.Nickname };
    }
}