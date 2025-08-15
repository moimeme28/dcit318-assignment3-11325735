using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Question 5: Inventory Logger System

// a. Define immutable inventory record
public record InventoryItem(int Id, string Name, int Quantity, DateTime DateAdded);

// b. Define marker interface for logging
public interface IInventoryEntity
{
    int Id { get; }
}

// Ensure InventoryItem implements IInventoryEntity
public record InventoryItem(int Id, string Name, int Quantity, DateTime DateAdded) : IInventoryEntity
{
    // This record automatically implements IInventoryEntity since it has an Id property
}

// c. Create generic inventory logger
public class InventoryLogger<T> where T : IInventoryEntity
{
    private List<T> _log = new List<T>();
    private string _filePath;

    public InventoryLogger(string filePath)
    {
        _filePath = filePath;
    }

    public void Add(T item)
    {
        _log.Add(item);
        Console.WriteLine($"Added item: {item}");
    }

    public List<T> GetAll()
    {
        return new List<T>(_log);
    }

    public void SaveToFile()
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            
            string jsonString = JsonSerializer.Serialize(_log, options);
            File.WriteAllText(_filePath, jsonString);
            Console.WriteLine($"Successfully saved {_log.Count} items to {_filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
            throw;
        }
    }

    public void LoadFromFile()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                Console.WriteLine($"File {_filePath} does not exist. Starting with empty inventory.");
                _log.Clear();
                return;
            }

            string jsonString = File.ReadAllText(_filePath);
            if (string.IsNullOrEmpty(jsonString))
            {
                Console.WriteLine("File is empty. Starting with empty inventory.");
                _log.Clear();
                return;
            }

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            _log = JsonSerializer.Deserialize<List<T>>(jsonString, options) ?? new List<T>();
            Console.WriteLine($"Successfully loaded {_log.Count} items from {_filePath}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error parsing JSON from file: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading from file: {ex.Message}");
            throw;
        }
    }
}

// f. Create InventoryApp class
public class InventoryApp
{
    private InventoryLogger<InventoryItem> _logger;

    public InventoryApp()
    {
        _logger = new InventoryLogger<InventoryItem>("inventory.json");
    }

    public void SeedSampleData()
    {
        Console.WriteLine("=== Seeding Sample Data ===");
        
        _logger.Add(new InventoryItem(1, "Laptop", 5, DateTime.Now.AddDays(-10)));
        _logger.Add(new InventoryItem(2, "Mouse", 20, DateTime.Now.AddDays(-5)));
        _logger.Add(new InventoryItem(3, "Keyboard", 15, DateTime.Now.AddDays(-3)));
        _logger.Add(new InventoryItem(4, "Monitor", 8, DateTime.Now.AddDays(-1)));
        _logger.Add(new InventoryItem(5, "Headphones", 12, DateTime.Now));
        
        Console.WriteLine($"Added {_logger.GetAll().Count} sample items");
    }

    public void SaveData()
    {
        Console.WriteLine("=== Saving Data ===");
        _logger.SaveToFile();
    }

    public void LoadData()
    {
        Console.WriteLine("=== Loading Data ===");
        _logger.LoadFromFile();
    }

    public void PrintAllItems()
    {
        Console.WriteLine("=== Current Inventory ===");
        var items = _logger.GetAll();
        
        if (items.Count == 0)
        {
            Console.WriteLine("No items in inventory.");
        }
        else
        {
            foreach (var item in items)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}, Date Added: {item.DateAdded:yyyy-MM-dd}");
            }
        }
        Console.WriteLine($"Total items: {items.Count}");
    }
}

// Main application
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Inventory Logger System ===");
        
        var inventoryApp = new InventoryApp();
        
        try
        {
            // Seed sample data
            inventoryApp.SeedSampleData();
            
            // Save data to file
            inventoryApp.SaveData();
            
            // Clear memory and simulate new session
            Console.WriteLine("\n=== Simulating New Session ===");
            inventoryApp = new InventoryApp(); // Create new instance to simulate new session
            
            // Load data from file
            inventoryApp.LoadData();
            
            // Print all items to confirm data was recovered
            inventoryApp.PrintAllItems();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in main application: {ex.Message}");
        }
    }
} 