using MediatR;

namespace ATM.Application.Features.MachineFeatures.Commands.FillMachine
{
    public sealed record class FillMachineCommand (Guid MachineId, Guid BanknoteId, int Amount) : IRequest;
}
