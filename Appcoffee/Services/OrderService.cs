using System.Collections.ObjectModel;
using Appcoffee.Models;

namespace Appcoffee.Services;

public sealed class OrderService
{
    public ObservableCollection<Order> Orders { get; } = [];
    public void Save(IEnumerable<CartItem> items, decimal total)
    {
        Orders.Insert(0, new Order { Id = $"#{DateTime.Now:MMddHHmm}", Items = items.ToList(), Total = total, Date = DateTime.Now });
    }
}
