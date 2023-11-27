using ATM.Domain.Entities;
using ATM.Domain.Exceptions;
using ATM.Domain.Repositories;
using MediatR;

namespace ATM.Application.Features.MachineFeatures.Commands.FillMachine
{
    internal class FillMachineCommandHandler : IRequestHandler<FillMachineCommand>
    {
        private readonly IMachineRepository _machineRepository;
        private readonly IBanknoteRepository _banknoteRepository;
        public FillMachineCommandHandler(IMachineRepository machineRepository, IBanknoteRepository banknoteRepository)
        {
            _machineRepository = machineRepository;
            _banknoteRepository = banknoteRepository;

        }
        public Task Handle(FillMachineCommand request, CancellationToken cancellationToken)
        {
            var machine = _machineRepository.Find(x => x.Id == request.MachineId, "MachineNotes");

            if (machine == null) throw new MachineNoteFoundException();

            var banknote = _banknoteRepository.Find(x => x.Id == request.BanknoteId);

            if (banknote == null) throw new BanknoteNotFountException();

            machine.AddBanknote(new MachineNote(machine, banknote, request.Amount));

            _machineRepository.Update(machine);

            return Task.CompletedTask;
        }
    }
}
