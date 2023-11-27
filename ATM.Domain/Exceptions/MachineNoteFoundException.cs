namespace ATM.Domain.Exceptions
{
    public sealed class MachineNoteFoundException : Exception
    {
        public MachineNoteFoundException() : base("Máquina não encontrada.")
        {
            
        }
    }
}
