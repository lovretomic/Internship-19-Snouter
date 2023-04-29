namespace Snouter.Contracts.Responses;

public class ValidationFailureResponse
{
    public IEnumerable<ValidationResponse> Errors { get; set; }
}

public class ValidationResponse
{
    public string PropertyName { get; init; }
    public string Message { get; init; }
}