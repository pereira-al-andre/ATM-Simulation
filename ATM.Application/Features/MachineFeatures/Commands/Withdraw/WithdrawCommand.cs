using ATM.Application.Abstractions.Responses;
using MediatR;

namespace ATM.Application.Features.MachineFeatures.Commands.Withdraw
{
    public sealed record class WithdrawCommand(Guid MachineId, int Amount) : IRequest<WithdrawResponse>;
}
