using ATM.Domain.Common.Interfaces;
using ATM.Domain.Entities;
using ATM.Domain.Exceptions;
using ATM.Domain.Repositories;
using ATM.Infrastructure.Persistence;
using ATM.Infrastructure.Repositories.Common;

namespace ATM.Infrastructure.Repositories
{
    public sealed class BanknoteRepository : Repository<Banknote>, IBanknoteRepository
    {
        public BanknoteRepository(SqlDBContext context) : base(context)
        { }

        public void Remove(Banknote entity)
        {
            try
            {
                if (entity is not IRemovableEntity)
                    throw new IRemovableInterfaceNotImplementedException<Banknote>(entity);

                entity.Remove();

                _DbSet.Update(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Banknote entity)
        {
            try
            {
                if (entity is not IUpdatableEntity)
                    throw new IUpdatableInterfaceNotImplementedException<Banknote>(entity);

                entity.SetUpdateDate();

                _DbSet.Update(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void UpdateAsync(Banknote entity)
        {
            try
            {
                if (entity is not IUpdatableEntity)
                    throw new IUpdatableInterfaceNotImplementedException<Banknote>(entity);

                entity.SetUpdateDate();

                _DbSet.Update(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
