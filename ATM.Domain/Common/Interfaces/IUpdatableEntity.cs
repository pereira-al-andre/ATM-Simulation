namespace ATM.Domain.Common.Interfaces
{
    public interface IUpdatableEntity
    {
        public abstract DateTime? UpdatedAt { get; }
        public void SetUpdateDate();
    }
}
