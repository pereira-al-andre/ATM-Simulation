namespace ATM.Domain.Common.Interfaces
{
    public interface IRemovableEntity
    {
        public abstract bool Removed { get; }
        public void Remove();
    }
}
