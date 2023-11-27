namespace ATM.Application.Abstractions.Responses
{
    public sealed class MachineBalanceResponse
    {
        public MachineBalanceResponse(
            Guid machineId,
            string machineName,
            Dictionary<string, int> availableNotes)
        {
            MachineId = machineId;
            MachineName = machineName;
            AvailableNotes = availableNotes;
        }

        public Guid MachineId { get; private set; }
        public string MachineName { get; private set; } = null!;
        public Dictionary<string, int> AvailableNotes { get; private set; }
    }
}
