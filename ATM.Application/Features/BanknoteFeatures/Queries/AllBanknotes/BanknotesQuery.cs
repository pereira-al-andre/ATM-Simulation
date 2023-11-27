using MediatR;

namespace ATM.Application.Features.BanknoteFeatures.Queries.AllBanknotes
{
    public sealed class BanknotesQuery : IRequest<Dictionary<string, int>>
    {
    }
}
