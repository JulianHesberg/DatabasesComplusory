using DatabasesComplusory.Application.Commands;
using DatabasesComplusory.Application.Commands.UserCommandHandlers;
using DatabasesComplusory.Application.Commands.UserCommands;
using DatabasesComplusory.Application.Handlers.UserHandlers;
using DatabasesComplusory.Domain.Entities.Read;
using Microsoft.AspNetCore.Mvc;

namespace DatabasesComplusory.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly GetUserCommandHandler _getUserHandler;
    private readonly CreateUserCommandHandler _createUserHandler;

    public UserController(GetUserCommandHandler getUserHandler, CreateUserCommandHandler createUserHandler)
    {
        _getUserHandler = getUserHandler;
        _createUserHandler = createUserHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        try
        {
            // Handler now returns the new User entity
            var newUser = await _createUserHandler.HandleAsync(command);

            // Map domain User to read model or return domain model directly
            var createdRead = new UserRead
            {
                UserId = newUser.UserId,
                Name = newUser.Name,
                Email = newUser.Email
            };

            // Return 201 Created, with the Location header and the new user read model in the body
            return CreatedAtAction(
                nameof(Get),
                new { id = newUser.UserId },
                createdRead
            );
        } catch (Exception ex)
        {
            // Handle exceptions (e.g., validation errors, database errors) and return appropriate status codes
            return BadRequest(new { error = ex.Message });
        }


    }

    [HttpGet("{id}", Name = "GetUserById")]
    public async Task<ActionResult<UserRead>> Get(int id)
    {
        try
        {
            var user = await _getUserHandler.HandleAsync(new GetUserCommand { UserId = id });
            return Ok(user);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}