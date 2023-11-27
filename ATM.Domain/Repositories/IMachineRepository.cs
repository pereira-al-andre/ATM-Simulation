using ATM.Domain.Entities;
using ATM.Domain.Repositories.Common;

namespace ATM.Domain.Repositories
{
    public interface IMachineRepository 
        : IRepository<Machine>, IUpdatable<Machine>, IRemovable<Machine>
    { }
}
