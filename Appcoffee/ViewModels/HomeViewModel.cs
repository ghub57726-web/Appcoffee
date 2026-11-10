using System.Collections.ObjectModel;
using Appcoffee.Models;
using Appcoffee.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Appcoffee.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly ProductService products;
    private readonly CartService cart;
    private readonly WishlistService wishlist;
    public ObservableCollection<Product> FilteredProducts { get; } = [];
    public IReadOnlyList<string> Categories { get; } = ["All", "Espresso", "Cappuccino", "Latte", "Americano"];
    [ObservableProperty] private string searchText = string.Empty;
    [ObservableProperty] private string selectedCategory = "All";
    [ObservableProperty] private int cartCount;
    [ObservableProperty] private bool isFilterVisible;
    public HomeViewModel(ProductService products, CartService cart, WishlistService wishlist)
    {
        this.products = products; this.cart = cart; this.wishlist = wishlist;
        cart.Changed += (_, _) => CartCount = cart.Count;
        Refresh();
    }
    partial void OnSearchTextChanged(string value) => Refresh();
    partial void OnSelectedCategoryChanged(string value) => Refresh();
    private void Refresh()
    {
        var query = products.GetAll().Where(x => (SelectedCategory == "All" || x.Category == SelectedCategory) && (string.IsNullOrWhiteSpace(SearchText) || x.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase)));
        FilteredProducts.Clear(); foreach (var item in query) FilteredProducts.Add(item);
    }
    [RelayCommand] private void SelectCategory(string category) => SelectedCategory = category;
    [RelayCommand] private void ToggleFilter() => IsFilterVisible = !IsFilterVisible;
    [RelayCommand] private void AddToCart(Product product) => cart.Add(product);
    [RelayCommand] private Task OpenProduct(Product product) => Shell.Current.GoToAsync($"productdetail?productId={product.Id}");
    [RelayCommand] private Task SeeAll() => Shell.Current.GoToAsync("list");
    [RelayCommand] private Task OpenCart() => Shell.Current.GoToAsync("cart");
    [RelayCommand] private Task OpenWishlist() => Shell.Current.GoToAsync("wishlist");
    [RelayCommand] private Task OpenOrders() => Shell.Current.GoToAsync("orders");
}
