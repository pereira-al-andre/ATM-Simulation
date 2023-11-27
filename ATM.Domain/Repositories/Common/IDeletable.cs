using ATM.Domain.Common;

namespace ATM.Domain.Repositories.Common
{
    public interface IDeletable<TEntity> where TEntity : Entity
    {
        public void Delete(TEntity entity);
    }
}
