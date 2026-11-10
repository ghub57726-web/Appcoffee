using Appcoffee.ViewModels;
namespace Appcoffee.Views;
public partial class OrderPage : ContentPage { public OrderPage(OrderViewModel vm) { InitializeComponent(); BindingContext = vm; } }
