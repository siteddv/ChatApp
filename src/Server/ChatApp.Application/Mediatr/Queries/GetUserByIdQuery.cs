using ChatApp.Application.Dtos;
using MediatR;

namespace ChatApp.Application.Mediatr.Queries;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public Guid UserId { get; set; }
}