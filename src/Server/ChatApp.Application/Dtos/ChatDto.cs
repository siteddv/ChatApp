using ChatApp.Domain.Common.Enums;

namespace ChatApp.Application.Dtos;

public class ChatDto
{
    public Guid Id { get; set; }
    public ChatType Type { get; set; }
    public Guid? GroupId { get; set; }
    public List<UserDto> Participants { get; set; } = new List<UserDto>();
}