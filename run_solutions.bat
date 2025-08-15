@echo off
echo === C# Programming Solutions Runner ===
echo.

echo Choose a solution to run:
echo 1. Finance Management System
echo 2. Healthcare System  
echo 3. Warehouse Inventory Management
echo 4. Grading System
echo 5. Inventory Logger System
echo 6. Run All Solutions
echo.

set /p choice="Enter your choice (1-6): "

if "%choice%"=="1" goto question1
if "%choice%"=="2" goto question2
if "%choice%"=="3" goto question3
if "%choice%"=="4" goto question4
if "%choice%"=="5" goto question5
if "%choice%"=="6" goto runall
goto invalid

:question1
echo.
echo Running Finance Management System...
dotnet run --project Question1_FinanceManagement.cs
goto end

:question2
echo.
echo Running Healthcare System...
dotnet run --project Question2_HealthcareSystem.cs
goto end

:question3
echo.
echo Running Warehouse Inventory Management...
dotnet run --project Question3_WarehouseInventory.cs
goto end

:question4
echo.
echo Running Grading System...
dotnet run --project Question4_GradingSystem.cs
goto end

:question5
echo.
echo Running Inventory Logger System...
dotnet run --project Question5_InventoryLogger.cs
goto end

:runall
echo.
echo Running All Solutions...
dotnet run --project RunAllSolutions.cs
goto end

:invalid
echo Invalid choice. Please enter a number between 1 and 6.
goto end

:end
echo.
echo Press any key to exit...
pause >nul 