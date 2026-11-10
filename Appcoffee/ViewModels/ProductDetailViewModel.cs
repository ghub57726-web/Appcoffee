using Appcoffee.Models;
using Appcoffee.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Appcoffee.ViewModels;

public partial class ProductDetailViewModel : ObservableObject
{
    private readonly ProductService products;
    private readonly CartService cart;
    private readonly WishlistService wishlist;
    [ObservableProperty] private Product? product;
    [ObservableProperty] private string selectedSize = "Medium";
    [ObservableProperty] private int quantity = 1;
    [ObservableProperty] private bool isDescriptionExpanded;
    [ObservableProperty] private bool isFavorite;
    public decimal Price => Product is null ? 0 : (Product.BasePrice + SizeExtra) * Quantity;
    public decimal SizeExtra => SelectedSize switch { "Large" => 4m, "Medium" => 2m, _ => 0m };
    public ProductDetailViewModel(ProductService products, CartService cart, WishlistService wishlist) { this.products = products; this.cart = cart; this.wishlist = wishlist; }
    public void Load(int id) { Product = products.GetById(id); IsFavorite = Product is not null && wishlist.Contains(Product); OnPropertyChanged(nameof(Price)); }
    partial void OnSelectedSizeChanged(string value) => OnPropertyChanged(nameof(Price));
    partial void OnQuantityChanged(int value) => OnPropertyChanged(nameof(Price));
    [RelayCommand] private void SetSize(string size) => SelectedSize = size;
    [RelayCommand] private void IncreaseQuantity() => Quantity++;
    [RelayCommand] private void DecreaseQuantity() => Quantity = Math.Max(1, Quantity - 1);
    [RelayCommand] private void ToggleFavorite() { if (Product is null) return; wishlist.Toggle(Product); IsFavorite = wishlist.Contains(Product); }
    [RelayCommand] private void ToggleDescription() => IsDescriptionExpanded = !IsDescriptionExpanded;
    [RelayCommand] private void AddToCart() { if (Product is not null) cart.Add(Product, SelectedSize, Quantity); }
    [RelayCommand] private Task GoBack() => Shell.Current.GoToAsync("..");
}
