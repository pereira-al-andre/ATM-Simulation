using ATM.Domain.Common;

namespace ATM.Domain.Repositories.Common
{
    public interface IUpdatable<TEntity> where TEntity : Entity
    {
        public void Update(TEntity entity);
    }
}
