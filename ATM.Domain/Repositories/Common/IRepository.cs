using ATM.Domain.Common;
using System.Linq.Expressions;

namespace ATM.Domain.Repositories.Common
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        public TEntity? Find(Guid id);
        public TEntity? Find(Expression<Func<TEntity, bool>> filter);
        public Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> filter, string includes);
        public TEntity? Find(Guid id, string includes);
        public TEntity? Find(Expression<Func<TEntity, bool>> filter, string includes);
        public IEnumerable<TEntity> All();
        public IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> filter);
        public TEntity Create(TEntity entity);
        public Task<TEntity> CreateAsync(TEntity entity);
    }
}
