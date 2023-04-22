﻿namespace Snouter.Application.Models.Item;

public class Item
{
    public Guid Id { get; init; }
    public Guid AuthorId { get; set; }
    public string? Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Category { get; set; }
    public string? Description { get; set; }
    public List<string> ImageLinks { get; set; } = new();
    public decimal Price { get; set; }
    public string? Currency { get; set; }
}