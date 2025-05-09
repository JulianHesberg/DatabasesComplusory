namespace DatabasesComplusory.Application.Events.UserEvents;

public class ReviewCreatedEvent
{
    public int ReviewId { get; set; }
    public int UserId { get; set; }
    public int SellerId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
}