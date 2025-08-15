# C# Programming Solutions Runner
Write-Host "=== C# Programming Solutions Runner ===" -ForegroundColor Green
Write-Host ""

Write-Host "Choose a solution to run:" -ForegroundColor Yellow
Write-Host "1. Finance Management System"
Write-Host "2. Healthcare System"  
Write-Host "3. Warehouse Inventory Management"
Write-Host "4. Grading System"
Write-Host "5. Inventory Logger System"
Write-Host "6. Run All Solutions"
Write-Host ""

$choice = Read-Host "Enter your choice (1-6)"

switch ($choice) {
    "1" {
        Write-Host ""
        Write-Host "Running Finance Management System..." -ForegroundColor Cyan
        dotnet run --project Question1_FinanceManagement.cs
    }
    "2" {
        Write-Host ""
        Write-Host "Running Healthcare System..." -ForegroundColor Cyan
        dotnet run --project Question2_HealthcareSystem.cs
    }
    "3" {
        Write-Host ""
        Write-Host "Running Warehouse Inventory Management..." -ForegroundColor Cyan
        dotnet run --project Question3_WarehouseInventory.cs
    }
    "4" {
        Write-Host ""
        Write-Host "Running Grading System..." -ForegroundColor Cyan
        dotnet run --project Question4_GradingSystem.cs
    }
    "5" {
        Write-Host ""
        Write-Host "Running Inventory Logger System..." -ForegroundColor Cyan
        dotnet run --project Question5_InventoryLogger.cs
    }
    "6" {
        Write-Host ""
        Write-Host "Running All Solutions..." -ForegroundColor Cyan
        dotnet run --project RunAllSolutions.cs
    }
    default {
        Write-Host "Invalid choice. Please enter a number between 1 and 6." -ForegroundColor Red
    }
}

Write-Host ""
Write-Host "Press any key to exit..."
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown") 