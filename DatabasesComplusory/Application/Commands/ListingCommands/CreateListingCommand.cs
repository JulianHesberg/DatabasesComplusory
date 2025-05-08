using DatabasesComplusory.Application.DTO;

namespace DatabasesComplusory.Application.Commands.ListingCommands;

public class CreateListingCommand
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int SellerId { get; set; }
    public IEnumerable<MediaDto> Media { get; set; }
}