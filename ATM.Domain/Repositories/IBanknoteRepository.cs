using ATM.Domain.Entities;
using ATM.Domain.Repositories.Common;

namespace ATM.Domain.Repositories
{
    public interface IBanknoteRepository 
        : IRepository<Banknote>, IUpdatable<Banknote>, IRemovable<Banknote>
    { }
}
