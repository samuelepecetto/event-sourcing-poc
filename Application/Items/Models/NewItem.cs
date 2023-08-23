namespace EventSourcing.Application.Items.Models;

public record NewItem(string DisplayName, decimal Price, ItemCategory Category);
public record ExistingItem(Guid Id, string DisplayName, decimal Price, ItemCategory Category);
public enum ItemCategory
{
    Other = 1,
    Pants,
    Shirts,
    Shoes,
    Hats,
}
