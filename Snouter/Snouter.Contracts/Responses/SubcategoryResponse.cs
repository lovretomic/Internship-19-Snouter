namespace Snouter.Contracts.Responses;

public class SubcategoryResponse
{
    public string? Name { get; set; }
    public string? CategoryName { get; set; }
    public object AdditionalProps { get; set; } = new object();
}