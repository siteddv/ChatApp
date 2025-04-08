namespace ChatApp.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Nickname { get; set; } = string.Empty;
    public ICollection<Group> Groups { get; set; } = new List<Group>();
    public ICollection<Chat> Chats { get; set; } = new List<Chat>();
}