namespace OnlineShop.Models.Products.Computers.Children
{
    public class DesktopComputer : Computer
    {
        private const double defaultOverallPerformance = 15;

        public DesktopComputer(int id, string manufacturer, string model, decimal price) 
            : base(id, manufacturer, model, price, defaultOverallPerformance)
        {
        }
    }
}
