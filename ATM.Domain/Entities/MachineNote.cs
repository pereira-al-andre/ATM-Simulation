using ATM.Domain.Common;
using ATM.Domain.Exceptions;

namespace ATM.Domain.Entities
{
    public sealed class MachineNote : Entity
    {
        internal MachineNote()
             : base(Guid.NewGuid())
        { }

        public MachineNote(
            Machine machine,
            Banknote banknote)
            :base(Guid.NewGuid())
        {
            MachineId = machine.Id;
            BanknoteId = banknote.Id;
        }

        public MachineNote(
            Machine machine,
            Banknote banknote,
            int amount)
            : base(Guid.NewGuid())
        {
            MachineId = machine.Id;
            BanknoteId = banknote.Id;

            if (amount <= 0) 
                throw new TryingToAddLessThanOrEqualZeroNotesException(amount);

            Amount = amount;
        }

        public Guid MachineId { get; private set; }
        public Guid BanknoteId { get; private set; }
        public int Amount { get; private set; } = 1;

        internal void Decrease(int amount)
        {
            if (Amount == 0) 
                throw new TryingToWithdrawFromZeroBanknotesException(amount, Amount);

            if (Amount < amount)
                throw new InsufficientAmountAvailable(amount, Amount);

            Amount -= 1;
        }

        internal void Increase(int amount) => Amount += amount;

        public Banknote Banknote { get; private set; } = null!;
        public Machine Machine { get; private set; } = null!;
    }
}
