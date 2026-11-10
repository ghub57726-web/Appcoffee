using Appcoffee.ViewModels;
namespace Appcoffee.Views;
[QueryProperty(nameof(ProductId), "productId")]
public partial class ProductDetailPage : ContentPage
{
    private readonly ProductDetailViewModel vm;
    public string ProductId { set { if (int.TryParse(Uri.UnescapeDataString(value), out var id)) vm.Load(id); } }
    public ProductDetailPage(ProductDetailViewModel vm) { InitializeComponent(); this.vm = vm; BindingContext = vm; }
}
