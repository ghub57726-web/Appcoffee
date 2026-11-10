using System.Collections.ObjectModel;
using Appcoffee.Models;
using Appcoffee.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Appcoffee.ViewModels;

public partial class WishlistViewModel : ObservableObject
{
    private readonly WishlistService wishlist;
    public ObservableCollection<Product> Items => wishlist.Items;
    public WishlistViewModel(WishlistService wishlist) { this.wishlist = wishlist; wishlist.Changed += (_, _) => OnPropertyChanged(nameof(Items)); }
    [RelayCommand] private Task OpenProduct(Product product) => Shell.Current.GoToAsync($"productdetail?productId={product.Id}");
    [RelayCommand] private Task GoBack() => Shell.Current.GoToAsync("..");
}
