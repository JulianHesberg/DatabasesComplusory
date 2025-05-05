namespace DatabasesComplusory.Models;

public class Order
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public int ListingId { get; set; }
    public int Quantity { get; set; }
}