namespace Snouter.Application.Models;

public class Subcategory
{
    public string Name { get; set; }
    public string CategoryName { get; set; }
    public object AdditionalProps { get; set; } = new object();
}