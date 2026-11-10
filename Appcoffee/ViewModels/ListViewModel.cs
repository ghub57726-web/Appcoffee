using System.Collections.ObjectModel;
using Appcoffee.Models;
using Appcoffee.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Appcoffee.ViewModels;

public partial class ListViewModel : ObservableObject
{
    public ObservableCollection<Product> Products { get; } = [];
    public ListViewModel(ProductService service) { foreach (var product in service.GetAll()) Products.Add(product); }
    [RelayCommand] private Task OpenProduct(Product product) => Shell.Current.GoToAsync($"productdetail?productId={product.Id}");
    [RelayCommand] private Task GoBack() => Shell.Current.GoToAsync("..");
}
