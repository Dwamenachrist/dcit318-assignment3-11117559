namespace Question1_FinanceSystem;

public class MobileMoneyProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"Mobile Money: Processing GHC {transaction.Amount:0.00} for {transaction.Category}");
    }
}