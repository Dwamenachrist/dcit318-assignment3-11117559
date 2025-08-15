namespace Question3_WarehouseSystem;

public class WarehouseManager
{
    public InventoryRepository<ElectronicItem> _electronics = new();
    public InventoryRepository<GroceryItem> _groceries = new();

    public void SeedData()
    {
        try
        {
            // Add electronic items
            _electronics.AddItem(new ElectronicItem(1, "Laptop", 10, "Dell", 24));
            _electronics.AddItem(new ElectronicItem(2, "Smartphone", 15, "Samsung", 12));
            _electronics.AddItem(new ElectronicItem(3, "Tablet", 8, "Apple", 12));

            // Add grocery items
            _groceries.AddItem(new GroceryItem(101, "Rice", 50, DateTime.Now.AddMonths(6)));
            _groceries.AddItem(new GroceryItem(102, "Pasta", 30, DateTime.Now.AddMonths(12)));
            _groceries.AddItem(new GroceryItem(103, "Canned Beans", 25, DateTime.Now.AddYears(2)));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error seeding data: {ex.Message}");
        }
    }

    public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
    {
        var items = repo.GetAllItems();
        foreach (var item in items)
        {
            Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}");
        }
        Console.WriteLine();
    }

    public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
    {
        try
        {
            var item = repo.GetItemById(id);
            repo.UpdateQuantity(id, item.Quantity + quantity);
            Console.WriteLine($"Stock increased for item {id}. New quantity: {item.Quantity + quantity}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error increasing stock: {ex.Message}");
        }
    }

    public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
    {
        try
        {
            repo.RemoveItem(id);
            Console.WriteLine($"Item {id} removed successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error removing item: {ex.Message}");
        }
    }
}
