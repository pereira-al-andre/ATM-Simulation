using ATM.Domain.Repositories;
using MediatR;

namespace ATM.Application.Features.BanknoteFeatures.Queries.AllBanknotes
{
    public sealed class BanknotesQueryHandler : IRequestHandler<BanknotesQuery, Dictionary<string, int>>
    {
        private readonly IBanknoteRepository _banknoteRepository;
        public BanknotesQueryHandler(IBanknoteRepository banknoteRepository)
        {
            _banknoteRepository = banknoteRepository;
        }
        public Task<Dictionary<string, int>> Handle(BanknotesQuery request, CancellationToken cancellationToken)
        {
            var notes = _banknoteRepository.All().ToList();

            Dictionary<string, int> result = new Dictionary<string, int>();

            notes.ForEach(n => result.Add(n.Name, n.Amount));

            return Task.FromResult(result);

        }
    }
}
