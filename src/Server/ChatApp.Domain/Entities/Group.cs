namespace ChatApp.Domain.Entities;

public class Group
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<User> Members { get; set; } = new List<User>();
    public ICollection<Chat> Chats { get; set; } = new List<Chat>();
}