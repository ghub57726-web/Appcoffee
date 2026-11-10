namespace Appcoffee.Models;

public sealed class Order
{
    public string Id { get; init; } = string.Empty;
    public IReadOnlyList<CartItem> Items { get; init; } = [];
    public decimal Total { get; init; }
    public DateTime Date { get; init; }
}
