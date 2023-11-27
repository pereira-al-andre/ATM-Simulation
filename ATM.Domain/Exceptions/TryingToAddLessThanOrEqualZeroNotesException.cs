namespace ATM.Domain.Exceptions
{
    public sealed class TryingToAddLessThanOrEqualZeroNotesException : Exception
    {
        public TryingToAddLessThanOrEqualZeroNotesException(int amount) 
            : base($"É necessário informar um valor maior que zero para adicionar à máquina. Valor informado: {amount}")
        { }
    }
}
