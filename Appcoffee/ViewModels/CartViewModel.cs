using System.Collections.ObjectModel;
using Appcoffee.Models;
using Appcoffee.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Appcoffee.ViewModels;

public partial class CartViewModel : ObservableObject
{
    private readonly CartService cart;
    private readonly OrderService orders;
    [ObservableProperty] private string discountCode = string.Empty;
    [ObservableProperty] private string? discountError;
    [ObservableProperty] private string? confirmationMessage;
    [ObservableProperty] private decimal subtotal;
    [ObservableProperty] private decimal delivery;
    [ObservableProperty] private decimal tax;
    [ObservableProperty] private decimal discount;
    [ObservableProperty] private decimal total;
    public ObservableCollection<CartItem> Items => cart.Items;
    public CartViewModel(CartService cart, OrderService orders) { this.cart = cart; this.orders = orders; cart.Changed += (_, _) => Refresh(); Refresh(); }
    private void Refresh() { Subtotal = cart.Subtotal; Delivery = cart.Delivery; Tax = cart.Tax; Discount = cart.Discount; Total = cart.Total; DiscountError = cart.DiscountError; OnPropertyChanged(nameof(Items)); }
    [RelayCommand] private void ApplyDiscount() => cart.ApplyDiscount(DiscountCode);
    [RelayCommand] private void Increase(CartItem item) => cart.ChangeQty(item, 1);
    [RelayCommand] private void Decrease(CartItem item) => cart.ChangeQty(item, -1);
    [RelayCommand] private void Remove(CartItem item) => cart.Remove(item);
    [RelayCommand] private void Checkout() { if (cart.Items.Count == 0) return; orders.Save(cart.Items, cart.Total); cart.Clear(); ConfirmationMessage = "Order placed successfully. Thank you for choosing Appcoffee!"; }
    [RelayCommand] private Task GoBack() => Shell.Current.GoToAsync("..");
}
