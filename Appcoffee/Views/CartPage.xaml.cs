using Appcoffee.ViewModels;
namespace Appcoffee.Views;
public partial class CartPage : ContentPage { public CartPage(CartViewModel vm) { InitializeComponent(); BindingContext = vm; } }
