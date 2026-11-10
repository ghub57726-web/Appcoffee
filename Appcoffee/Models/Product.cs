namespace Appcoffee.Models;

public sealed class Product
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Category { get; init; } = string.Empty;
    public decimal BasePrice { get; init; }
    public string Image { get; init; } = "coffee_placeholder.svg";
    public double Rating { get; init; }
    public string Description { get; init; } = string.Empty;
}
