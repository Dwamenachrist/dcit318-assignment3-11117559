namespace Question1_FinanceSystem;

public class FinanceApp
{
    private List<Transaction> _transactions = new();

    public void Run()
    {
        // Create account
        var account = new SavingsAccount("ACC001", 1000m);
        Console.WriteLine($"Account created with balance: GHC {account.Balance:0.00}");
        Console.WriteLine();

        // Create transactions
        var transaction1 = new Transaction(1, DateTime.Now, 50m, "Groceries");
        var transaction2 = new Transaction(2, DateTime.Now, 100m, "Utilities");
        var transaction3 = new Transaction(3, DateTime.Now, 25m, "Entertainment");

        // Process transactions
        var mobileProcessor = new MobileMoneyProcessor();
        var bankProcessor = new BankTransferProcessor();
        var cryptoProcessor = new CryptoWalletProcessor();

        mobileProcessor.Process(transaction1);
        bankProcessor.Process(transaction2);
        cryptoProcessor.Process(transaction3);
        Console.WriteLine();

        // Apply to account
        account.ApplyTransaction(transaction1);
        account.ApplyTransaction(transaction2);
        account.ApplyTransaction(transaction3);

        // Add to transactions list
        _transactions.Add(transaction1);
        _transactions.Add(transaction2);
        _transactions.Add(transaction3);
    }
}
