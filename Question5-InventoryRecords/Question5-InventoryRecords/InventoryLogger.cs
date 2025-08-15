namespace Question5_InventoryRecords;

public class InventoryLogger<T> where T : IInventoryEntity
{
    private List<T> _log = new();
    private string _filePath;

    public InventoryLogger(string filePath)
    {
        _filePath = filePath;
    }

    public void Add(T item)
    {
        _log.Add(item);
    }

    public List<T> GetAll()
    {
        return _log;
    }

    public void SaveToFile()
    {
        try
        {
            using var writer = new StreamWriter(_filePath);
            foreach (var item in _log)
            {
                if (item is InventoryItem inventoryItem)
                {
                    writer.WriteLine($"{inventoryItem.Id},{inventoryItem.Name},{inventoryItem.Quantity},{inventoryItem.DateAdded:yyyy-MM-dd}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
        }
    }

    public void LoadFromFile()
    {
        try
        {
            _log.Clear();
            if (File.Exists(_filePath))
            {
                using var reader = new StreamReader(_filePath);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    var fields = line.Split(',');
                    if (fields.Length == 4 && int.TryParse(fields[0], out int id) && 
                        int.TryParse(fields[2], out int quantity) && 
                        DateTime.TryParse(fields[3], out DateTime date))
                    {
                        var item = new InventoryItem(id, fields[1], quantity, date);
                        _log.Add((T)(object)item);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading from file: {ex.Message}");
        }
    }
}
