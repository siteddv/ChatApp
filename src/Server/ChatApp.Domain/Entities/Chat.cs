using ChatApp.Domain.Common.Enums;

namespace ChatApp.Domain.Entities;

public class Chat : BaseEntity
{
    public ChatType Type { get; set; }
    public string? Name { get; set; }
    public ICollection<ChatUser> Participants { get; set; } = new List<ChatUser>();
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}