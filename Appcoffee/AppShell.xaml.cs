using Appcoffee.Views;

namespace Appcoffee
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("list", typeof(ListPage));
            Routing.RegisterRoute("productdetail", typeof(ProductDetailPage));
            Routing.RegisterRoute("cart", typeof(CartPage));
            Routing.RegisterRoute("wishlist", typeof(WishlistPage));
            Routing.RegisterRoute("orders", typeof(OrderPage));
        }
    }
}
