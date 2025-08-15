# C# Programming Solutions

This repository contains solutions for 5 comprehensive C# programming problems covering various advanced concepts including records, interfaces, generics, collections, exception handling, and file operations.

## Solutions Overview

### Question 1: Finance Management System
**File:** `Question1_FinanceManagement.cs`
- **Concepts:** Records, Interfaces, Sealed Classes, Inheritance
- **Features:**
  - Transaction record with immutable data
  - Interface-based transaction processors (Bank, Mobile Money, Crypto)
  - Base Account class with virtual methods
  - Sealed SavingsAccount with balance validation
  - Modular finance application

### Question 2: Healthcare System
**File:** `Question2_HealthcareSystem.cs`
- **Concepts:** Generics, Collections, LINQ
- **Features:**
  - Generic Repository<T> for entity management
  - Patient and Prescription classes
  - Dictionary-based prescription grouping
  - LINQ operations for data manipulation

### Question 3: Warehouse Inventory Management
**File:** `Question3_WarehouseInventory.cs`
- **Concepts:** Generics, Custom Exceptions, Collections
- **Features:**
  - Marker interface IInventoryItem
  - Generic InventoryRepository<T> with constraints
  - Custom exceptions (DuplicateItemException, ItemNotFoundException, InvalidQuantityException)
  - Electronic and Grocery item types
  - Comprehensive exception handling

### Question 4: Grading System
**File:** `Question4_GradingSystem.cs`
- **Concepts:** File Operations, Custom Exceptions, Data Validation
- **Features:**
  - Student class with grade calculation
  - Custom exceptions for data validation
  - File reading/writing with proper exception handling
  - CSV parsing with field validation
  - Grade report generation

### Question 5: Inventory Logger System
**File:** `Question5_InventoryLogger.cs`
- **Concepts:** Records, Generics, JSON Serialization, File Operations
- **Features:**
  - Immutable InventoryItem record
  - Generic InventoryLogger<T> with constraints
  - JSON serialization for data persistence
  - File-based storage and retrieval
  - Session simulation with data recovery

## How to Run

### Prerequisites
- .NET 6.0 or later
- Visual Studio 2022 or VS Code with C# extension

### Running Individual Solutions

Each solution can be run independently. Here are the commands:

```bash
# Question 1: Finance Management
dotnet run --project Question1_FinanceManagement.cs

# Question 2: Healthcare System
dotnet run --project Question2_HealthcareSystem.cs

# Question 3: Warehouse Inventory
dotnet run --project Question3_WarehouseInventory.cs

# Question 4: Grading System
dotnet run --project Question4_GradingSystem.cs

# Question 5: Inventory Logger
dotnet run --project Question5_InventoryLogger.cs
```

### Expected Outputs

#### Question 1 Output:
```
=== Finance Management System ===
Mobile Money: Processing $50.00 for Groceries
Bank Transfer: Processing $75.00 for Utilities
Crypto Wallet: Processing $25.00 for Entertainment
Updated balance: $950.00
Updated balance: $875.00
Updated balance: $850.00

Final account balance: $850.00
Total transactions processed: 3
```

#### Question 2 Output:
```
=== Healthcare System ===
=== All Patients ===
Patient ID: 1, Name: John Doe, Age: 35, Gender: Male
Patient ID: 2, Name: Jane Smith, Age: 28, Gender: Female
Patient ID: 3, Name: Bob Johnson, Age: 45, Gender: Male

=== Prescriptions for Patient ID: 1 ===
Prescription ID: 1, Patient ID: 1, Medication: Aspirin, Date: 2024-01-15
Prescription ID: 2, Patient ID: 1, Medication: Ibuprofen, Date: 2024-01-20
```

#### Question 3 Output:
```
=== Warehouse Inventory Management System ===
=== GroceryItem Inventory ===
Grocery Item - ID: 101, Name: Milk, Quantity: 20, Expiry: 2024-01-27
Grocery Item - ID: 102, Name: Bread, Quantity: 15, Expiry: 2024-01-23
Grocery Item - ID: 103, Name: Eggs, Quantity: 30, Expiry: 2024-02-03

=== ElectronicItem Inventory ===
Electronic Item - ID: 1, Name: Laptop, Quantity: 5, Brand: Dell, Warranty: 24 months
Electronic Item - ID: 2, Name: Smartphone, Quantity: 10, Brand: Samsung, Warranty: 12 months
Electronic Item - ID: 3, Name: Tablet, Quantity: 8, Brand: Apple, Warranty: 12 months

=== Testing Exception Handling ===
Caught DuplicateItemException: Item with ID 1 already exists in inventory.
Error removing item: Item with ID 999 not found in inventory.
Caught InvalidQuantityException: Quantity cannot be negative.
Caught ItemNotFoundException: Item with ID 999 not found in inventory.
```

#### Question 4 Output:
```
=== Grading System ===
Sample input file created: students.txt
Reading student data from file...
Successfully read 5 students from file.
Generating grade report...
Grade report written to grade_report.txt

=== Summary ===
Alice Smith (ID: 101): Score = 84, Grade = A
Bob Johnson (ID: 102): Score = 72, Grade = B
Carol Davis (ID: 103): Score = 95, Grade = A
David Wilson (ID: 104): Score = 68, Grade = C
Eva Brown (ID: 105): Score = 45, Grade = F
```

#### Question 5 Output:
```
=== Inventory Logger System ===
=== Seeding Sample Data ===
Added item: InventoryItem { Id = 1, Name = Laptop, Quantity = 5, DateAdded = 1/15/2024 10:30:00 AM }
Added item: InventoryItem { Id = 2, Name = Mouse, Quantity = 20, DateAdded = 1/20/2024 10:30:00 AM }
Added item: InventoryItem { Id = 3, Name = Keyboard, Quantity = 15, DateAdded = 1/22/2024 10:30:00 AM }
Added item: InventoryItem { Id = 4, Name = Monitor, Quantity = 8, DateAdded = 1/24/2024 10:30:00 AM }
Added item: InventoryItem { Id = 5, Name = Headphones, Quantity = 12, DateAdded = 1/25/2024 10:30:00 AM }
Added 5 sample items
=== Saving Data ===
Successfully saved 5 items to inventory.json
=== Simulating New Session ===
=== Loading Data ===
Successfully loaded 5 items from inventory.json
=== Current Inventory ===
ID: 1, Name: Laptop, Quantity: 5, Date Added: 2024-01-15
ID: 2, Name: Mouse, Quantity: 20, Date Added: 2024-01-20
ID: 3, Name: Keyboard, Quantity: 15, Date Added: 2024-01-22
ID: 4, Name: Monitor, Quantity: 8, Date Added: 2024-01-24
ID: 5, Name: Headphones, Quantity: 12, Date Added: 2024-01-25
Total items: 5
```

## Key Learning Objectives

### Advanced C# Concepts Covered:

1. **Records** - Immutable data structures with value semantics
2. **Interfaces** - Contract-based programming and polymorphism
3. **Generics** - Type-safe, reusable code with constraints
4. **Collections** - List<T>, Dictionary<K,V>, LINQ operations
5. **Exception Handling** - Custom exceptions and proper error management
6. **File Operations** - Reading/writing files with proper resource management
7. **JSON Serialization** - Data persistence and recovery
8. **Sealed Classes** - Inheritance control and final implementations
9. **Virtual Methods** - Polymorphic behavior in inheritance hierarchies
10. **Data Validation** - Input validation and business rule enforcement

### Design Patterns Used:

- **Repository Pattern** - Generic data access layer
- **Strategy Pattern** - Interface-based algorithm selection
- **Factory Pattern** - Object creation with type safety
- **Observer Pattern** - Event-driven processing
- **Template Method Pattern** - Base class with customizable steps

## File Structure

```
├── Question1_FinanceManagement.cs    # Finance system with records and interfaces
├── Question2_HealthcareSystem.cs     # Healthcare system with generics and collections
├── Question3_WarehouseInventory.cs   # Warehouse system with custom exceptions
├── Question4_GradingSystem.cs        # Grading system with file operations
├── Question5_InventoryLogger.cs      # Inventory logger with JSON persistence
└── README.md                         # This documentation file
```

## Additional Notes

- All solutions include comprehensive error handling
- Code follows C# best practices and conventions
- Solutions demonstrate real-world application scenarios
- Each solution is self-contained and can run independently
- Proper resource management with `using` statements
- Type safety enforced through generics and constraints

## Requirements Met

✅ **Question 1**: Records, Interfaces, Sealed Classes, Inheritance Control  
✅ **Question 2**: Generics, Collections, LINQ, Type Safety  
✅ **Question 3**: Custom Exceptions, Generic Constraints, Exception Handling  
✅ **Question 4**: File Operations, Data Validation, Custom Exceptions  
✅ **Question 5**: Records, Generics, JSON Serialization, File Persistence  

All solutions are production-ready and demonstrate advanced C# programming concepts with proper error handling and best practices. 