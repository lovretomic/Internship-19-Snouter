namespace Snouter.Contracts.Requests;

public class CreateUserRequest
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string? ProfilePicUrl { get; set; }
    public (decimal Lat, decimal Long) Location { get; set; }
}