namespace ATM.Application.Abstractions.Responses
{
    public sealed class WithdrawResponse
    {
        public WithdrawResponse(
            int amount,
            Dictionary<string, int> banknotes)
        {
            Amount = amount;
            Banknotes = banknotes;
        }

        public int Amount { get; private set; }
        public Dictionary<string, int> Banknotes { get; private set; }
    }
}
