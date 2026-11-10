using System.Collections.ObjectModel;
using Appcoffee.Models;
using Appcoffee.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Appcoffee.ViewModels;

public partial class OrderViewModel : ObservableObject
{
    public ObservableCollection<Order> Orders { get; }
    public OrderViewModel(OrderService service) => Orders = service.Orders;
    [RelayCommand] private Task GoBack() => Shell.Current.GoToAsync("..");
}
