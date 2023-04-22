namespace Snouter.Api;

public static class ApiEndpoints
{
    private const string ApiBase = "api";

    public static class User
    {
        public const string Get = $"{ApiBase}/{{id:guid}}";
    }
}