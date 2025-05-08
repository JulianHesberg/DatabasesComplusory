using DatabasesComplusory.Application.Commands;
using DatabasesComplusory.Application.Commands.ListingCommands;

using DatabasesComplusory.Domain.Entities.Read;
using Microsoft.AspNetCore.Mvc;

namespace DatabasesComplusory.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListingController : ControllerBase
{
    private readonly CreateListingCommandHandler _createListingHandler;

    public ListingController(CreateListingCommandHandler createListingHandler)
    {
        _createListingHandler = createListingHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateListingCommand command)
    {
        try
        {
            // Handler now returns the new User entity
            var newListing = await _createListingHandler.HandleAsync(command);

            // Map domain User to read model or return domain model directly
            var createdRead = new ListingRead
            {
                ListingId = newListing.ListingId,
                Name = newListing.Name,
                Description = newListing.Description,
                Price = newListing.Price,
                Quantity = newListing.Quantity,
                SellerId = newListing.SellerId
            };

            // Return 201 Created, with the Location header and the new user read model in the body
            return Ok(
                createdRead
            );
        } catch (Exception ex)
        {
            // Handle exceptions (e.g., validation errors, database errors) and return appropriate status codes
            return BadRequest(new { error = ex.Message });
        }


    }
}