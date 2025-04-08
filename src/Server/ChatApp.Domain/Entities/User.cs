namespace ChatApp.Domain.Entities;

public class User : BaseEntity
{
    public string Nickname { get; set; } = string.Empty;
    public ICollection<Chat> Chats { get; set; } = new List<Chat>();
}