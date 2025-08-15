namespace Question5_InventoryRecords;

public class InventoryApp
{
    private InventoryLogger<InventoryItem> _logger;

    public InventoryApp()
    {
        _logger = new InventoryLogger<InventoryItem>("inventory.txt");
    }

    public void SeedSampleData()
    {
        _logger.Add(new InventoryItem(1, "Laptop", 10, DateTime.Now.AddDays(-5)));
        _logger.Add(new InventoryItem(2, "Mouse", 25, DateTime.Now.AddDays(-3)));
        _logger.Add(new InventoryItem(3, "Keyboard", 15, DateTime.Now.AddDays(-2)));
        _logger.Add(new InventoryItem(4, "Monitor", 8, DateTime.Now.AddDays(-1)));
        _logger.Add(new InventoryItem(5, "Headphones", 20, DateTime.Now));
        
        Console.WriteLine("Sample data added successfully");
    }

    public void SaveData()
    {
        _logger.SaveToFile();
        Console.WriteLine("Data saved to file");
    }

    public void LoadData()
    {
        _logger.LoadFromFile();
        Console.WriteLine("Data loaded from file");
    }

    public void PrintAllItems()
    {
        var items = _logger.GetAll();
        Console.WriteLine("\n=== Inventory Items ===");
        foreach (var item in items)
        {
            Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}, Date Added: {item.DateAdded:yyyy-MM-dd}");
        }
    }
}
