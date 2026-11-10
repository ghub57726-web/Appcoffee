using Appcoffee.Models;

namespace Appcoffee.Services;

public sealed class ProductService
{
    private readonly List<Product> products =
    [
        new() { Id = 1, Name = "Espresso", Category = "Espresso", BasePrice = 4.50m, Image = "coffee_placeholder.svg", Rating = 4.9, Description = "A bold, concentrated shot with a smooth crema and a rich roasted finish." },
        new() { Id = 2, Name = "Cappuccino", Category = "Cappuccino", BasePrice = 5.25m, Image = "coffee_placeholder.svg", Rating = 4.8, Description = "Velvety steamed milk and airy foam balanced over a deeply aromatic espresso." },
        new() { Id = 3, Name = "Vanilla Latte", Category = "Latte", BasePrice = 5.75m, Image = "coffee_placeholder.svg", Rating = 4.9, Description = "Silky milk, fragrant vanilla, and freshly brewed espresso come together in every sip." },
        new() { Id = 4, Name = "Iced Americano", Category = "Americano", BasePrice = 4.95m, Image = "coffee_placeholder.svg", Rating = 4.7, Description = "Crisp, refreshing espresso over ice with a clean and pleasantly bittersweet finish." },
        new() { Id = 5, Name = "Caramel Macchiato", Category = "Latte", BasePrice = 6.25m, Image = "coffee_placeholder.svg", Rating = 4.9, Description = "A creamy latte layered with caramel sweetness and an extra espresso kick." },
        new() { Id = 6, Name = "Flat White", Category = "Cappuccino", BasePrice = 5.50m, Image = "coffee_placeholder.svg", Rating = 4.8, Description = "A beautifully balanced coffee with glossy microfoam and a powerful espresso core." },
        new() { Id = 7, Name = "Classic Americano", Category = "Americano", BasePrice = 4.25m, Image = "coffee_placeholder.svg", Rating = 4.6, Description = "Simple, elegant, and full-bodied: espresso lengthened with hot water." },
        new() { Id = 8, Name = "Double Espresso", Category = "Espresso", BasePrice = 5.00m, Image = "coffee_placeholder.svg", Rating = 4.9, Description = "Twice the roast character, served short for coffee lovers who like intensity." }
    ];

    public IReadOnlyList<Product> GetAll() => products;
    public Product? GetById(int id) => products.FirstOrDefault(x => x.Id == id);
}
