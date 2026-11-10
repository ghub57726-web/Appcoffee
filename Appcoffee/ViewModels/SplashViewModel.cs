using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Appcoffee.ViewModels;

public partial class SplashViewModel : ObservableObject
{
    [RelayCommand]
    private Task GetStarted() => Shell.Current.GoToAsync("//home");
}
