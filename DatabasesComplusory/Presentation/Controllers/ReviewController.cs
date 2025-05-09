using DatabasesComplusory.Application.Commands.ReviewCommandHandlers;
using DatabasesComplusory.Application.Commands.ReviewCommands;
using DatabasesComplusory.Application.Domain.Entities.Read;
using DatabasesComplusory.Application.ReviewCommandHandlers;
using Microsoft.AspNetCore.Mvc;

namespace DatabasesComplusory.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly GetReviewByIdCommandHandler _byIdHandler;
    private readonly GetReviewsBySellerCommandHandler _bySellerHandler;
    private readonly CreateReviewCommandHandler _createHandler;

    public ReviewsController(
        GetReviewByIdCommandHandler byIdHandler,
        GetReviewsBySellerCommandHandler bySellerHandler,
        CreateReviewCommandHandler createHandler)
    {
        _byIdHandler = byIdHandler;
        _bySellerHandler = bySellerHandler;
        _createHandler = createHandler;
    }

    [HttpGet("{id}", Name = "GetReviewById")]
    public async Task<ActionResult<ReviewRead>> GetById(int id)
    {
        try
        {
            var review = await _byIdHandler.HandleAsync(new GetReviewByIdCommand { ReviewId = id });
            return Ok(review);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("seller/{sellerId}")]
    public async Task<ActionResult<List<ReviewRead>>> GetBySeller(int sellerId)
    {
        var reviews = await _bySellerHandler.HandleAsync(new GetReviewsBySellerIdCommand { SellerId = sellerId });
        return Ok(reviews);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReviewCommand cmd)
    {
        var created = await _createHandler.HandleAsync(cmd);
        var read = await _byIdHandler.HandleAsync(new GetReviewByIdCommand { ReviewId = created.ReviewId });
        return CreatedAtRoute("GetReviewById", new { id = read.ReviewId }, read);
    }
}


