namespace ATM.Application.Abstractions.Responses
{
    public sealed class BanknotesResponse
    {
        public BanknotesResponse(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }

        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
