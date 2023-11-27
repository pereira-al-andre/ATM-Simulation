namespace ATM.Domain.Exceptions
{
    public sealed class BanknoteNeedsToBeGreaterThanZeroException : Exception
    {
        public BanknoteNeedsToBeGreaterThanZeroException(int amount) 
            : base($"A nota precisa ter uma valor maior do que zero. O valor {amount} foi informado.")
        {
            
        }
    }
}
