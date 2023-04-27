﻿namespace Snouter.Contracts.Requests;

public class UpdateUserRequest
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? ProfilePicUrl { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
}