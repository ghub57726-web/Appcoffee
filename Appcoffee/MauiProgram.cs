using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Appcoffee.Services;
using Appcoffee.ViewModels;
using Appcoffee.Views;

namespace Appcoffee
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("OpenSans-Regular.ttf", "Poppins");
                });

            builder.Services.AddSingleton<ProductService>();
            builder.Services.AddSingleton<CartService>();
            builder.Services.AddSingleton<WishlistService>();
            builder.Services.AddSingleton<OrderService>();
            builder.Services.AddTransient<SplashViewModel>();
            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<ListViewModel>();
            builder.Services.AddTransient<ProductDetailViewModel>();
            builder.Services.AddTransient<CartViewModel>();
            builder.Services.AddTransient<WishlistViewModel>();
            builder.Services.AddTransient<OrderViewModel>();
            builder.Services.AddTransient<SplashPage>();
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<ListPage>();
            builder.Services.AddTransient<ProductDetailPage>();
            builder.Services.AddTransient<CartPage>();
            builder.Services.AddTransient<WishlistPage>();
            builder.Services.AddTransient<OrderPage>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
