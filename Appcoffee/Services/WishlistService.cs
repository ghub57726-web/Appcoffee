using System.Collections.ObjectModel;
using Appcoffee.Models;

namespace Appcoffee.Services;

public sealed class WishlistService
{
    public ObservableCollection<Product> Items { get; } = [];
    public event EventHandler? Changed;
    public bool Contains(Product product) => Items.Any(x => x.Id == product.Id);
    public void Toggle(Product product)
    {
        var existing = Items.FirstOrDefault(x => x.Id == product.Id);
        if (existing is null) Items.Add(product); else Items.Remove(existing);
        Changed?.Invoke(this, EventArgs.Empty);
    }
}
