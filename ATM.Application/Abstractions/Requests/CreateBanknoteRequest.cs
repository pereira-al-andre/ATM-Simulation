namespace ATM.Application.Abstractions.Requests
{
    public sealed class CreateBanknoteRequest
    {
        public string Name { get; set; } = null!;
        public int Amout { get; set; }
    }
}
