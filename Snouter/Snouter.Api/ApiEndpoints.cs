﻿namespace Snouter.Api;

public static class ApiEndpoints
{
    private const string ApiBase = "api";

    public static class User
    {
        private const string UserBase = $"{ApiBase}/users";
        public const string Create = UserBase;
        public const string GetAll = UserBase;
        public const string GetById = $"{UserBase}/{{id:guid}}";
        public const string Update = $"{UserBase}/{{id:guid}}";
        public const string DeleteById = $"{UserBase}/{{id:guid}}";
    }

    public static class Category
    {
        private const string CategoryBase = $"{ApiBase}/categories";
        public const string Create = CategoryBase;
        public const string GetAll = CategoryBase;
        public const string Update = $"{CategoryBase}/{{name:string}}";
        public const string DeleteByName = $"{CategoryBase}/{{name:string}}";
    }
}