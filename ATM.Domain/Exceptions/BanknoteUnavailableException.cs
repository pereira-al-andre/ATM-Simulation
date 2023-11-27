using ATM.Domain.Entities;

namespace ATM.Domain.Exceptions
{
    public sealed class BanknoteUnavailableException : Exception
    {
        public BanknoteUnavailableException(Banknote banknote) 
            : base($"A cédula {banknote.Name} não está disponível nesa máquina.")
        { }
    }
}
