namespace DatabasesComplusory.Models.Write;

public class Review
{
    public int ReviewId { get; set; }
    public int UserId { get; set; }
    public int SellerId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
}