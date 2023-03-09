namespace Bakery.Models.Drinks
{
    using Bakery.Models.Drinks.Base;

    public class Water : Drink
    {
        private const decimal WaterPrice = 1.50m;

        public Water(string name, int portion, string brand) 
            : base(name, portion, WaterPrice, brand)
        {
        }
    }
}
