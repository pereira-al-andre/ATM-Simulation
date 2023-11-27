namespace ATM.Domain.Exceptions
{
    public sealed class BanknoteNotFountException : Exception
    {
        public BanknoteNotFountException() : base("Nota informada não encontrada.")
        {
                
        }
    }
}
