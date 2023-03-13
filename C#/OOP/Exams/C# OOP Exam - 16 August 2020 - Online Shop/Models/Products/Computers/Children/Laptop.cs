namespace OnlineShop.Models.Products.Computers.Children
{
    public class Laptop : Computer
    {
        private const double defaultOverallPerformance = 10;

        public Laptop(int id, string manufacturer, string model, decimal price)
            : base(id, manufacturer, model, price, defaultOverallPerformance)
        {
        }
    }
}
