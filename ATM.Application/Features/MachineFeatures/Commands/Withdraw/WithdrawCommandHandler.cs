using ATM.Application.Abstractions.Responses;
using ATM.Domain.Entities;
using ATM.Domain.Exceptions;
using ATM.Domain.Repositories;
using MediatR;
using System.Threading.Tasks;

namespace ATM.Application.Features.MachineFeatures.Commands.Withdraw
{
    public sealed class WithdrawCommandHandler : IRequestHandler<WithdrawCommand, WithdrawResponse>
    {
        private readonly IMachineRepository _machineRepository;
        public WithdrawCommandHandler(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }

        public Task<WithdrawResponse> Handle(WithdrawCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var machine = _machineRepository.Find(command.MachineId, "MachineNotes.Banknote");

                if (machine is null)
                    throw new MachineNoteFoundException();

                var result = Withdraw(ref machine, command.Amount);

                _machineRepository.Update(machine);

                var response = new WithdrawResponse(command.Amount, result);

                return Task.FromResult(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Dictionary<string, int> Withdraw(ref Machine machine, int amount)
        {
            try
            {
                if (machine.MachineNotes.Count == 0) throw new NoAvailableNotesException();

                var availableNotes = machine.MachineNotes.Where(mn => mn.Amount > 0).OrderByDescending(x => x.Banknote.Amount);

                if (availableNotes.Count() == 0) throw new NoAvailableNotesException();

                var notes = availableNotes.Select(x => x.Banknote);

                var max = notes.MaxBy(x => x.Amount);
                var min = notes.MinBy(x => x.Amount);

                if (amount > min.Amount) throw new NoAvailableNotesException();

                if ((amount % min.Amount) != 0) throw new OutOfRangeBanknotesAmountException(notes.Select(x => x.Name).ToArray());

                Dictionary<string, int> result = new Dictionary<string, int>();

                foreach (var note in notes)
                {
                    var d = amount / note.Amount;

                    if (d <= 0) continue;

                    var total = Convert.ToInt32(Math.Round((decimal)(amount / note.Amount)));

                    amount -= total * note.Amount;

                    machine.RemoveBanknote(note, total);

                    result.Add(note.Name, total);
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
