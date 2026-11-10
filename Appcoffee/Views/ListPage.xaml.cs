using Appcoffee.ViewModels;
namespace Appcoffee.Views;
public partial class ListPage : ContentPage { public ListPage(ListViewModel vm) { InitializeComponent(); BindingContext = vm; } }
