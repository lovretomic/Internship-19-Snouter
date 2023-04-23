namespace Snouter.Api;

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
        public const string DeleteByName = $"{CategoryBase}/{{name}}";
    }

    public static class Subcategory
    {
        private const string SubcategoryBase = $"{ApiBase}/{{categoryName}}";
        public const string Create = SubcategoryBase;
        public const string GetAll = $"{ApiBase}/subcategories";
        public const string DeleteByName = $"{SubcategoryBase}/{{name}}";
    }

    public static class Item
    {
        private const string ItemBase = $"{ApiBase}/items";
        public const string Create = ItemBase;
        public const string GetById = $"{ItemBase}/{{id:guid}}";
        public const string Update = $"{ItemBase}/{{id:guid}}";
        public const string DeleteById = $"{ItemBase}/{{id:guid}}";
    }
}