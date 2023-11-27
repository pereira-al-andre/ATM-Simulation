namespace ATM.Domain.Exceptions
{
    public sealed class OutOfRangeBanknotesAmountException : Exception
    {
        public OutOfRangeBanknotesAmountException(string[] availableNotes) 
            : base($"O valor inserido não pode ser sacado, este caixa só possui as seguintes notas: {String.Join(',', availableNotes)}")
        { }
    }
}
