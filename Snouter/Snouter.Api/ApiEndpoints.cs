namespace Snouter.Api;

public static class ApiEndpoints
{
    private const string ApiBase = "api";

    public static class User
    {
        public const string Create = $"{ApiBase}/users";
        public const string GetAll = $"{ApiBase}/users";
        public const string GetById = $"{ApiBase}/users/{{id:guid}}";
        public const string Update = $"{ApiBase}/users/{{id:guid}}";
        public const string DeleteById = $"{ApiBase}/users/{{id:guid}}";
    }
}