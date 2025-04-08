namespace ChatApp.Domain.Entities;

public class Message
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid SenderId { get; set; }
    public User Sender { get; set; } = null!;
    public Guid ChatId { get; set; }
    public Chat Chat { get; set; } = null!;
}