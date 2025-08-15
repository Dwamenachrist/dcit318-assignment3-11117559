using Question3_WarehouseSystem;

var manager = new WarehouseManager();
manager.SeedData();

Console.WriteLine("=== Electronic Items ===");
manager.PrintAllItems(manager._electronics);

Console.WriteLine("=== Grocery Items ===");
manager.PrintAllItems(manager._groceries);

// Test exception handling
Console.WriteLine("=== Testing Exception Handling ===");
try
{
    // Try to add duplicate item
    manager._electronics.AddItem(new ElectronicItem(1, "Duplicate Laptop", 5, "Dell", 24));
}
catch (Exception ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}

try
{
    // Try to remove non-existent item
    manager._electronics.RemoveItem(999);
}
catch (Exception ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}

try
{
    // Try to update with invalid quantity
    manager._electronics.UpdateQuantity(1, -5);
}
catch (Exception ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
