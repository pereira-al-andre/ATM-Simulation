using ATM.Domain.Common;

namespace ATM.Domain.Exceptions
{
    public sealed class IUpdatableInterfaceNotImplementedException<TEntity> : Exception where TEntity : Entity
    {
        public IUpdatableInterfaceNotImplementedException(TEntity entity) 
            : base($"A entidade {nameof(entity)} não implementa a interface IUpdatable")
        { }
    }
}
