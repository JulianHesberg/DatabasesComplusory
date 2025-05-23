namespace DatabasesComplusory.Domain.Entities.Write;

public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<Review> Reviews { get; set; }
}