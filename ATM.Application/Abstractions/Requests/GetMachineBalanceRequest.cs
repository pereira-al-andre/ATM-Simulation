namespace ATM.Application.Abstractions.Requests
{
    public sealed class GetMachineBalanceRequest
    {
        public Guid MachineId { get; set; }
    }
}
