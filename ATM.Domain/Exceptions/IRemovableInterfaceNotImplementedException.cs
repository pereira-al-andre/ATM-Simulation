using ATM.Domain.Common;

namespace ATM.Domain.Exceptions
{
    public sealed class IRemovableInterfaceNotImplementedException<TEntity> : Exception where TEntity : Entity
    {
        public IRemovableInterfaceNotImplementedException(TEntity entity) 
            : base($"A entidade {nameof(entity)} não implementa a interface IRemovableEntity")
        { }
    }
}
