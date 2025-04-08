namespace ChatApp.Application.Dtos;

public class MessageDto
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public UserDto Sender { get; set; } = null!;
    public Guid ChatId { get; set; }
}