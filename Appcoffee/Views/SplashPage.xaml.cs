using Appcoffee.ViewModels;
namespace Appcoffee.Views;
public partial class SplashPage : ContentPage { public SplashPage(SplashViewModel vm) { InitializeComponent(); BindingContext = vm; } }
