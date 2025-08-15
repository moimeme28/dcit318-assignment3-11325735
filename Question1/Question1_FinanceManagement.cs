using System;
using System.Collections.Generic;

// Question 1: Finance Management System

// a. Create a record type to represent financial data
public record Transaction(int Id, DateTime Date, decimal Amount, string Category);

// b. Define interface for transaction processing
public interface ITransactionProcessor
{
    void Process(Transaction transaction);
}

// c. Create three concrete classes implementing the interface
public class BankTransferProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"Bank Transfer: Processing ${transaction.Amount} for {transaction.Category}");
    }
}

public class MobileMoneyProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"Mobile Money: Processing ${transaction.Amount} for {transaction.Category}");
    }
}

public class CryptoWalletProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"Crypto Wallet: Processing ${transaction.Amount} for {transaction.Category}");
    }
}

// d. Define base class Account
public class Account
{
    public string AccountNumber { get; set; }
    public decimal Balance { get; protected set; }

    public Account(string accountNumber, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    public virtual void ApplyTransaction(Transaction transaction)
    {
        Balance -= transaction.Amount;
    }
}

// e. Define sealed class SavingsAccount
public sealed class SavingsAccount : Account
{
    public SavingsAccount(string accountNumber, decimal initialBalance) 
        : base(accountNumber, initialBalance)
    {
    }

    public override void ApplyTransaction(Transaction transaction)
    {
        if (transaction.Amount > Balance)
        {
            Console.WriteLine("Insufficient funds");
        }
        else
        {
            base.ApplyTransaction(transaction);
            Console.WriteLine($"Updated balance: ${Balance}");
        }
    }
}

// f. Create FinanceApp class
public class FinanceApp
{
    private List<Transaction> _transactions = new List<Transaction>();

    public void Run()
    {
        // i. Instantiate a SavingsAccount
        var savingsAccount = new SavingsAccount("SA001", 1000);

        // ii. Create three Transaction records
        var transaction1 = new Transaction(1, DateTime.Now, 50.00m, "Groceries");
        var transaction2 = new Transaction(2, DateTime.Now, 75.00m, "Utilities");
        var transaction3 = new Transaction(3, DateTime.Now, 25.00m, "Entertainment");

        // iii. Use processors to process each transaction
        var mobileProcessor = new MobileMoneyProcessor();
        var bankProcessor = new BankTransferProcessor();
        var cryptoProcessor = new CryptoWalletProcessor();

        mobileProcessor.Process(transaction1);
        bankProcessor.Process(transaction2);
        cryptoProcessor.Process(transaction3);

        // iv. Apply each transaction to the SavingsAccount
        savingsAccount.ApplyTransaction(transaction1);
        savingsAccount.ApplyTransaction(transaction2);
        savingsAccount.ApplyTransaction(transaction3);

        // v. Add all transactions to _transactions
        _transactions.Add(transaction1);
        _transactions.Add(transaction2);
        _transactions.Add(transaction3);

        Console.WriteLine($"\nFinal account balance: ${savingsAccount.Balance}");
        Console.WriteLine($"Total transactions processed: {_transactions.Count}");
    }
}

// Main application
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Finance Management System ===");
        var financeApp = new FinanceApp();
        financeApp.Run();
    }
} 