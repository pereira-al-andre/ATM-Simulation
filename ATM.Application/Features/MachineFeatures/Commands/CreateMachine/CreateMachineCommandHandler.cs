using ATM.Domain.Entities;
using ATM.Domain.Repositories;
using MediatR;

namespace ATM.Application.Features.MachineFeatures.Commands.CreateMachine
{
    public sealed class CreateMachineCommandHandler : IRequestHandler<CreateMachineCommand, Machine>
    {
        private readonly IMachineRepository _machineRepository;
        public CreateMachineCommandHandler(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }

        public async Task<Machine> Handle(CreateMachineCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var machine = new Machine(request.Name);

                await _machineRepository.CreateAsync(machine);

                return machine;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
