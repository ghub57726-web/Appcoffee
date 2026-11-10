using CommunityToolkit.Mvvm.ComponentModel;

namespace Appcoffee.Models;

public partial class CartItem : ObservableObject
{
    public Product Product { get; init; } = null!;
    public string Size { get; init; } = "Medium";
    public decimal UnitPrice { get; init; }
    [ObservableProperty] private int qty = 1;
    public decimal LineTotal => UnitPrice * Qty;
    partial void OnQtyChanged(int value) => OnPropertyChanged(nameof(LineTotal));
}
