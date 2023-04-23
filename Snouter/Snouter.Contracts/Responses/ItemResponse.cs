namespace Snouter.Contracts.Responses;

public class ItemResponse
{
    public Guid Id { get; init; }
    public Guid AuthorId { get; set; }
    public string? Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Subcategory { get; set; }
    public string? Description { get; set; }
    public List<string> ImageLinks { get; set; } = new();
    public decimal Price { get; set; }
    public string? Currency { get; set; }
    public object AdditionalProps { get; set; } = new();
}