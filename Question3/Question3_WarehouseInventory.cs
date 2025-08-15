using System;
using System.Collections.Generic;

// Question 3: Warehouse Inventory Management System

// a. Create marker interface for inventory items
public interface IInventoryItem
{
    int Id { get; }
    string Name { get; }
    int Quantity { get; set; }
}

// e. Define custom exceptions
public class DuplicateItemException : Exception
{
    public DuplicateItemException(string message) : base(message) { }
}

public class ItemNotFoundException : Exception
{
    public ItemNotFoundException(string message) : base(message) { }
}

public class InvalidQuantityException : Exception
{
    public InvalidQuantityException(string message) : base(message) { }
}

// b. Define ElectronicItem class
public class ElectronicItem : IInventoryItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public string Brand { get; set; }
    public int WarrantyMonths { get; set; }

    public ElectronicItem(int id, string name, int quantity, string brand, int warrantyMonths)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        Brand = brand;
        WarrantyMonths = warrantyMonths;
    }

    public override string ToString()
    {
        return $"Electronic Item - ID: {Id}, Name: {Name}, Quantity: {Quantity}, Brand: {Brand}, Warranty: {WarrantyMonths} months";
    }
}

// c. Define GroceryItem class
public class GroceryItem : IInventoryItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpiryDate { get; set; }

    public GroceryItem(int id, string name, int quantity, DateTime expiryDate)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        ExpiryDate = expiryDate;
    }

    public override string ToString()
    {
        return $"Grocery Item - ID: {Id}, Name: {Name}, Quantity: {Quantity}, Expiry: {ExpiryDate:yyyy-MM-dd}";
    }
}

// d. Create generic inventory repository
public class InventoryRepository<T> where T : IInventoryItem
{
    private Dictionary<int, T> _items = new Dictionary<int, T>();

    public void AddItem(T item)
    {
        if (_items.ContainsKey(item.Id))
        {
            throw new DuplicateItemException($"Item with ID {item.Id} already exists in inventory.");
        }
        _items.Add(item.Id, item);
    }

    public T GetItemById(int id)
    {
        if (!_items.ContainsKey(id))
        {
            throw new ItemNotFoundException($"Item with ID {id} not found in inventory.");
        }
        return _items[id];
    }

    public void RemoveItem(int id)
    {
        if (!_items.ContainsKey(id))
        {
            throw new ItemNotFoundException($"Item with ID {id} not found in inventory.");
        }
        _items.Remove(id);
    }

    public List<T> GetAllItems()
    {
        return new List<T>(_items.Values);
    }

    public void UpdateQuantity(int id, int newQuantity)
    {
        if (newQuantity < 0)
        {
            throw new InvalidQuantityException("Quantity cannot be negative.");
        }

        if (!_items.ContainsKey(id))
        {
            throw new ItemNotFoundException($"Item with ID {id} not found in inventory.");
        }

        var item = _items[id];
        item.Quantity = newQuantity;
    }
}

// f. Create WareHouseManager class
public class WareHouseManager
{
    private InventoryRepository<ElectronicItem> _electronics;
    private InventoryRepository<GroceryItem> _groceries;

    public WareHouseManager()
    {
        _electronics = new InventoryRepository<ElectronicItem>();
        _groceries = new InventoryRepository<GroceryItem>();
    }

    public InventoryRepository<ElectronicItem> Electronics => _electronics;
    public InventoryRepository<GroceryItem> Groceries => _groceries;

    public void SeedData()
    {
        // Add electronic items
        _electronics.AddItem(new ElectronicItem(1, "Laptop", 5, "Dell", 24));
        _electronics.AddItem(new ElectronicItem(2, "Smartphone", 10, "Samsung", 12));
        _electronics.AddItem(new ElectronicItem(3, "Tablet", 8, "Apple", 12));

        // Add grocery items
        _groceries.AddItem(new GroceryItem(101, "Milk", 20, DateTime.Now.AddDays(7)));
        _groceries.AddItem(new GroceryItem(102, "Bread", 15, DateTime.Now.AddDays(3)));
        _groceries.AddItem(new GroceryItem(103, "Eggs", 30, DateTime.Now.AddDays(14)));
    }

    public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
    {
        var items = repo.GetAllItems();
        Console.WriteLine($"=== {typeof(T).Name} Inventory ===");
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }

    public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
    {
        try
        {
            var item = repo.GetItemById(id);
            repo.UpdateQuantity(id, item.Quantity + quantity);
            Console.WriteLine($"Successfully increased stock for item {id} by {quantity}");
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
            Console.WriteLine($"Successfully removed item {id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error removing item: {ex.Message}");
        }
    }
}

// Main application
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Warehouse Inventory Management System ===");
        
        var warehouseManager = new WareHouseManager();
        
        // Seed data
        warehouseManager.SeedData();
        
        // Print all items
        warehouseManager.PrintAllItems(warehouseManager.Groceries);
        warehouseManager.PrintAllItems(warehouseManager.Electronics);
        
        // Test exception handling
        Console.WriteLine("=== Testing Exception Handling ===");
        
        // Try to add a duplicate item
        try
        {
            warehouseManager.Electronics.AddItem(new ElectronicItem(1, "Duplicate Laptop", 1, "Dell", 24));
        }
        catch (DuplicateItemException ex)
        {
            Console.WriteLine($"Caught DuplicateItemException: {ex.Message}");
        }
        
        // Try to remove a non-existent item
        warehouseManager.RemoveItemById(warehouseManager.Groceries, 999);
        
        // Try to update with invalid quantity
        try
        {
            warehouseManager.Electronics.UpdateQuantity(1, -5);
        }
        catch (InvalidQuantityException ex)
        {
            Console.WriteLine($"Caught InvalidQuantityException: {ex.Message}");
        }
        
        // Try to get a non-existent item
        try
        {
            warehouseManager.Groceries.GetItemById(999);
        }
        catch (ItemNotFoundException ex)
        {
            Console.WriteLine($"Caught ItemNotFoundException: {ex.Message}");
        }
    }
} 