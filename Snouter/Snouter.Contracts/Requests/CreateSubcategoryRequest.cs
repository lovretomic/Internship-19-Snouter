namespace Snouter.Contracts.Requests;

public class CreateSubcategoryRequest
{
    public string? Name { get; set; }
    public object AdditionalProps { get; set; } = new object();
}