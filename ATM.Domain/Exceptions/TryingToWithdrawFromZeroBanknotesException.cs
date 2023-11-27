namespace ATM.Domain.Exceptions
{
    public sealed class TryingToWithdrawFromZeroBanknotesException : Exception
    {
        public TryingToWithdrawFromZeroBanknotesException(int amount, int available) 
            : base($"Tentativa de saque superior às notas existentes na máquina. Disponíveis: {available}, Saque: {amount}")
        { }
    }
}
