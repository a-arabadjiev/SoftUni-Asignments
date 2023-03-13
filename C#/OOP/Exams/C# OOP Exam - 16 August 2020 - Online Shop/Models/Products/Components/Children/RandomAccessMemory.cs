namespace OnlineShop.Models.Products.Components.Children
{
    public class RandomAccessMemory : Component
    {
        private const double defaultPerformanceMultiplier = 1.20;

        public RandomAccessMemory(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation)
            : base(id, manufacturer, model, price, overallPerformance * defaultPerformanceMultiplier, generation)
        {
        }
    }
}
