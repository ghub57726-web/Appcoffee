using Appcoffee.ViewModels;
namespace Appcoffee.Views;
public partial class WishlistPage : ContentPage { public WishlistPage(WishlistViewModel vm) { InitializeComponent(); BindingContext = vm; } }
