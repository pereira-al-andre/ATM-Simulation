namespace ATM.Application.Abstractions.Requests
{
    public sealed class WithdrawRequest
    {
        public Guid MachineId { get; set; }
        public int Amount { get; set; }
    }
}
