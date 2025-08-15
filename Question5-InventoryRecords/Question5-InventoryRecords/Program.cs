using Question5_InventoryRecords;

var app = new InventoryApp();

// Seed data
app.SeedSampleData();

// Save data
app.SaveData();

// Clear memory (simulate new session)
Console.WriteLine("Simulating new session...");

// Load data
app.LoadData();

// Print all items
app.PrintAllItems();

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
