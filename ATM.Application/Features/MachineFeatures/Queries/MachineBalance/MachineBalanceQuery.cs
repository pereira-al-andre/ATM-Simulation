using ATM.Application.Abstractions.Responses;
using MediatR;

namespace ATM.Application.Features.MachineFeatures.Queries.MachineBalance
{
    public sealed record class MachineBalanceQuery(Guid MachineId)
        : IRequest<MachineBalanceResponse>;
}
