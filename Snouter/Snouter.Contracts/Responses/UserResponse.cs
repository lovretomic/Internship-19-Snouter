namespace Snouter.Contracts.Responses;

public class UserResponse
{
    public Guid Id { get; init; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? ProfilePicUrl { get; set; }
    public (decimal Lat, decimal Long) Location { get; set; }
}