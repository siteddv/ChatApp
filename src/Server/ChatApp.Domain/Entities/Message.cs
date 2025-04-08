namespace ChatApp.Domain.Entities;

public class Message : BaseEntity
{
    public string Content { get; set; }
    public Guid SenderId { get; set; }
    public User Sender { get; set; } = null!;
    public Guid ChatId { get; set; }
    public Chat Chat { get; set; } = null!;
}