using ATM.Domain.Common.Interfaces;
using ATM.Domain.Entities;
using ATM.Domain.Exceptions;
using ATM.Domain.Repositories;
using ATM.Infrastructure.Persistence;
using ATM.Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace ATM.Infrastructure.Repositories
{
    public sealed class MachineRepository : Repository<Machine>, IMachineRepository
    {
        public MachineRepository(SqlDBContext context) : base (context)
        { }

        public void Remove(Machine entity)
        {
            try
            {
                if (entity is not IRemovableEntity)
                    throw new IRemovableInterfaceNotImplementedException<Machine>(entity);

                entity.Remove();

                _DbSet.Update(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Machine entity)
        {
            try
            {
                if (entity is not IUpdatableEntity)
                    throw new IUpdatableInterfaceNotImplementedException<Machine>(entity);

                entity.SetUpdateDate();

                _DbSet.Update(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
