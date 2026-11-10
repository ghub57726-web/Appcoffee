using System.Collections.ObjectModel;
using Appcoffee.Models;

namespace Appcoffee.Services;

public sealed class CartService
{
    public ObservableCollection<CartItem> Items { get; } = [];
    public event EventHandler? Changed;
    public decimal Discount { get; private set; }
    public string? DiscountError { get; private set; }
    public decimal Subtotal => Items.Sum(x => x.LineTotal);
    public decimal Delivery => Items.Count == 0 ? 0 : 10m;
    public decimal Tax => Math.Round((Subtotal - Discount) * 0.05m, 2);
    public decimal Total => Math.Max(0, Subtotal - Discount + Delivery + Tax);
    public int Count => Items.Sum(x => x.Qty);

    public void Add(Product product, string size = "Medium", int qty = 1)
    {
        var unitPrice = product.BasePrice + (size switch { "Large" => 4m, "Medium" => 2m, _ => 0m });
        var existing = Items.FirstOrDefault(x => x.Product.Id == product.Id && x.Size == size);
        if (existing is null)
        {
            var item = new CartItem { Product = product, Size = size, UnitPrice = unitPrice, Qty = qty };
            item.PropertyChanged += (_, _) => NotifyChanged();
            Items.Add(item);
        }
        else existing.Qty += qty;
        NotifyChanged();
    }

    public void Remove(CartItem item) { Items.Remove(item); NotifyChanged(); }
    public void ChangeQty(CartItem item, int delta) { item.Qty = Math.Max(1, item.Qty + delta); NotifyChanged(); }
    public bool ApplyDiscount(string? code)
    {
        if (string.Equals(code?.Trim(), "COFFEE10", StringComparison.OrdinalIgnoreCase)) { Discount = Subtotal * 0.10m; DiscountError = null; }
        else { Discount = 0; DiscountError = "Enter a valid discount code."; }
        NotifyChanged(); return DiscountError is null;
    }
    public void Clear() { Items.Clear(); Discount = 0; DiscountError = null; NotifyChanged(); }
    private void NotifyChanged() => Changed?.Invoke(this, EventArgs.Empty);
}
