using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain.Exceptions
{
    public sealed class InsufficientAmountAvailable : Exception
    {
        public InsufficientAmountAvailable(int amount, int available) : base($"Quantidade de notas insuficiente para o saque, disponíveis: {available}, tentativa: {amount}.")
        { }
    }
}
