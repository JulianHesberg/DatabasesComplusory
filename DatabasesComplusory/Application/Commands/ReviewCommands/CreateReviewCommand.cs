namespace DatabasesComplusory.Application.Commands.ReviewCommands;

public class CreateReviewCommand
{
    public int UserId { get; set; }
    public int SellerId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
}