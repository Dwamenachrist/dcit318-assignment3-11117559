namespace Question1_FinanceSystem;

public class CryptoWalletProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"Crypto Wallet: Processing GHC {transaction.Amount:0.00} for {transaction.Category}");
    }
}