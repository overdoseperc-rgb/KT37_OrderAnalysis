using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var orders = new List<Order>
            {
                new Order { CustomerName = "Иван", Amount = 1000, Date = new DateOnly(2026, 11, 1) },
                new Order { CustomerName = "Алина", Amount = 1800, Date = new DateOnly(2026, 11, 2) },
                new Order { CustomerName = "Олег", Amount = 800, Date = new DateOnly(2026, 11, 2) },
                new Order { CustomerName = "Мария", Amount = 900, Date = new DateOnly(2026, 11, 3) },
                new Order { CustomerName = "Иван", Amount = 1500, Date = new DateOnly(2026, 11, 4) },
                new Order { CustomerName = "Алина", Amount = 1200, Date = new DateOnly(2026, 11, 5) },
                new Order { CustomerName = "Мария", Amount = 1600, Date = new DateOnly(2026, 11, 6) },
                new Order { CustomerName = "Олег", Amount = 1000, Date = new DateOnly(2026, 11, 7) },
                new Order { CustomerName = "Иван", Amount = 1000, Date = new DateOnly(2026, 11, 8) },
                new Order { CustomerName = "Алина", Amount = 2000, Date = new DateOnly(2026, 11, 10) },
                new Order { CustomerName = "Олег", Amount = 9000, Date = new DateOnly(2026, 10, 31) },
                new Order { CustomerName = "Мария", Amount = 8000, Date = new DateOnly(2026, 11, 11) }
            };

            var startDate = new DateOnly(2026, 11, 1);
            var endDate = new DateOnly(2026, 11, 10);

            var topCustomers = orders
                .Where(order => order.Date >= startDate && order.Date <= endDate)
                .GroupBy(order => order.CustomerName)
                .Select(group => new
                {
                    Name = group.Key,
                    Total = group.Sum(order => order.Amount)
                })
                .OrderByDescending(customer => customer.Total)
                .Take(3);

            Console.WriteLine($"Топ-3 клиента за {startDate:dd.MM.yyyy}–{endDate:dd.MM.yyyy}:");
            foreach (var customer in topCustomers)
            {
                Console.WriteLine($"{customer.Name}: {customer.Total} руб.");
            }
        }
    }
}
