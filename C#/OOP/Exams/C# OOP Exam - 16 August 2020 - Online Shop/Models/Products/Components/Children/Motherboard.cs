namespace OnlineShop.Models.Products.Components.Children
{
    public class Motherboard : Component
    {
        private const double defaultPerformanceMultiplier = 1.25;

        public Motherboard(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation)
            : base(id, manufacturer, model, price, overallPerformance * defaultPerformanceMultiplier, generation)
        {
        }
    }
}
