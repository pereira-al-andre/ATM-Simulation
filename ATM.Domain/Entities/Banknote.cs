using ATM.Domain.Common;
using ATM.Domain.Common.Interfaces;
using ATM.Domain.Exceptions;

namespace ATM.Domain.Entities
{
    public sealed class Banknote : Entity, IRemovableEntity, IUpdatableEntity
    {
        public Banknote() 
            : base(Guid.NewGuid())
        { }

        public Banknote(
            string name, 
            int amount)
            : base(Guid.NewGuid())
        {
            Name = name;

            if (amount <= 0) 
                throw new BanknoteNeedsToBeGreaterThanZeroException(amount);

            Amount = amount;
        }

        public string Name { get; private set; } = null!;
        public int Amount { get; private set; }
         
        public DateTime? UpdatedAt { get; private set; } = null;

        public bool Removed { get; private set; } = false;

        public void Remove() => Removed = true;

        public void SetUpdateDate() => UpdatedAt = DateTime.Now;
    }
}
