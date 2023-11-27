using ATM.Domain.Common;

namespace ATM.Domain.Repositories.Common
{
    public interface IRemovable<TEntity> where TEntity : Entity
    {
        public void Remove(TEntity entity);
    }
}
