using Appcoffee.Models;

namespace Appcoffee.Views;

public sealed class AlternatingProductTemplateSelector : DataTemplateSelector
{
    public DataTemplate? LeftTemplate { get; set; }
    public DataTemplate? RightTemplate { get; set; }
    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var items = (container as BindableObject)?.BindingContext as IEnumerable<Product>;
        var view = container as Element;
        var collection = FindCollection(view);
        var index = collection?.ItemsSource?.Cast<object>().ToList().IndexOf(item) ?? 0;
        return index % 2 == 0 ? LeftTemplate! : RightTemplate!;
    }
    private static CollectionView? FindCollection(Element? element) { while (element is not null && element is not CollectionView) element = element.Parent; return element as CollectionView; }
}
