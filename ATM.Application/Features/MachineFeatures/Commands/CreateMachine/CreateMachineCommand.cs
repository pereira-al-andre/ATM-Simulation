using ATM.Domain.Entities;
using MediatR;

namespace ATM.Application.Features.MachineFeatures.Commands.CreateMachine
{
    public sealed record class CreateMachineCommand(string Name) : IRequest<Machine>;
}
