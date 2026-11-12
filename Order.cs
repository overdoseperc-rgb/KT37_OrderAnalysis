namespace ConsoleApp1
{
    internal class Order
    {
        public string CustomerName { get; init; } = "";
        public decimal Amount { get; init; }
        public DateOnly Date { get; init; }
    }
}
