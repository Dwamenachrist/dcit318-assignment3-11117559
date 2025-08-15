namespace Question1_FinanceSystem;

public class BankTransferProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"Bank Transfer: Processing GHC {transaction.Amount:0.00} for {transaction.Category}");
    }
}