using Appcoffee.ViewModels;
namespace Appcoffee.Views;
public partial class HomePage : ContentPage { public HomePage(HomeViewModel vm) { InitializeComponent(); BindingContext = vm; } }
