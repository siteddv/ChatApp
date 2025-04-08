using ChatApp.Domain.Common.Enums;

namespace ChatApp.Domain.Entities;

public class Chat
{
    public Guid Id { get; set; }
    public ChatType Type { get; set; }
    public Guid? GroupId { get; set; }
    public ICollection<User> Participants { get; set; } = new List<User>();
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}