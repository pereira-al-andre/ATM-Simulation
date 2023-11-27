namespace ATM.Application.Abstractions.Requests
{
    public sealed class FillMachineRequest
    {
        public Guid MachineId { get; set; }
        public Guid BanknoteId { get; set; }
        public int Amount { get; set; }
    }
}
