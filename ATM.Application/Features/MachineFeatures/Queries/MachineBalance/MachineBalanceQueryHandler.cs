using ATM.Application.Abstractions.Responses;
using ATM.Domain.Exceptions;
using ATM.Domain.Repositories;
using MediatR;

namespace ATM.Application.Features.MachineFeatures.Queries.MachineBalance
{
    public sealed class MachineBalanceQueryHandler : IRequestHandler<MachineBalanceQuery, MachineBalanceResponse>
    {
        private readonly IMachineRepository _machineRepository;
        public MachineBalanceQueryHandler(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }
        public async Task<MachineBalanceResponse> Handle(MachineBalanceQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var machine = await _machineRepository.FindAsync(x => x.Id == query.MachineId, "MachineNotes.Banknote");

                if (machine == null) throw new MachineNoteFoundException();

                var notes = new Dictionary<string, int>();

                machine.MachineNotes.ForEach(mn => notes.Add(mn.Banknote.Name, mn.Amount));

                return new MachineBalanceResponse(machine.Id, machine.Name, notes);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
