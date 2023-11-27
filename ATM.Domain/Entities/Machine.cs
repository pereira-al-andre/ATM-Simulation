using ATM.Domain.Common;
using ATM.Domain.Common.Interfaces;
using ATM.Domain.Exceptions;

namespace ATM.Domain.Entities
{
    public sealed class Machine : Entity, IRemovableEntity, IUpdatableEntity
    {
        public Machine( string name ) 
            : base (Guid.NewGuid())
        {
            Name = name;
        }

        public string Name { get; private set; } = null!;
        public List<MachineNote> MachineNotes { get; private set; } = new();

        public bool Removed { get; private set; } = false;

        public DateTime? UpdatedAt { get; private set; } = null;

        public void SetUpdateDate() => UpdatedAt = DateTime.Now;

        public void Remove() => Removed = true;

        public void AddBanknote(MachineNote machineNote) => MachineNotes.Add(machineNote);

        public void UpdateBanknote(Banknote banknote, int amount)
        {
            MachineNote machineNote = MachineNotes.SingleOrDefault(an => an.BanknoteId == banknote.Id) ?? throw new BanknoteUnavailableException(banknote);

            machineNote.Increase(amount);
        }

        public void RemoveBanknote(Banknote banknote, int amount)
        {
            MachineNote machineNote = MachineNotes.SingleOrDefault(an => an.BanknoteId == banknote.Id) ?? throw new BanknoteUnavailableException(banknote);

            machineNote.Decrease(amount);

            MachineNotes.Add(machineNote);
        }
    }
}
