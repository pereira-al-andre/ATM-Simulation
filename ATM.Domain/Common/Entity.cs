namespace ATM.Domain.Common
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }

        public Entity(Guid id)
        {
            Id = id;
        }
    }
}
