namespace ATM.Domain.Exceptions
{
    public sealed class NoAvailableNotesException : Exception
    {
        public NoAvailableNotesException() : base("Essa máquina não possiu notas disponíves para o saque.")
        {
            
        }
    }
}
