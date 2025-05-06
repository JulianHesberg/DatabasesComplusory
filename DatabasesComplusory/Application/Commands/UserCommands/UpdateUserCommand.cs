namespace DatabasesComplusory.Application.Commands;

public class UpdateUserCommand
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}