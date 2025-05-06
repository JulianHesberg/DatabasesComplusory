namespace DatabasesComplusory.Models.Write;

public class Listing
{
    public int ListingId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int SellerId { get; set; }
}