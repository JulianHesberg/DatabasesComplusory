using DatabasesComplusory.Domain.Entities.Write;

namespace DatabasesComplusory.Application.Events;

public class ListingCreatedEvent
{
    public int ListingId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int SellerId { get; set; }
    public int Quantity { get; set; }
    public List<Media> Media { get; set; }
}