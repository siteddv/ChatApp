using ChatApp.Domain.Common.Enums;

namespace ChatApp.Application.Dtos;

public class ChatDto
{
    public Guid Id { get; set; }
    public ChatType Type { get; set; }
    public string? Name { get; set; }
}