namespace DatabasesComplusory.Application.Events;

public class UserCreatedEvent
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}