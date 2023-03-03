namespace P04.PizzaCalories.Models
{
    using System.Collections.Generic;

    public class Topping
    {
        // Topping Type Multipliers
        private Dictionary<string, double> toppingTypeMultipliers;
        private readonly double baseMultiplier = 2.0;

        // Standard Fields
        private string type;
        private int grams;

        public Topping(string type, int grams)
        {
            this.SeedToppingTypeMultipliers();

            this.Type = type;
            this.Grams = grams;
        }

        private string Type
        {
            get 
            { 
                return this.type; 
            }
            set 
            {
                if (!this.toppingTypeMultipliers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value; 
            }
        }

        private int Grams
        {
            get
            {
                return this.grams;
            }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }
                this.grams = value;
            }
        }

        public double GetCalories()
        {
            double calories = ((this.baseMultiplier * this.Grams) * this.toppingTypeMultipliers[this.Type.ToLower()]);

            return calories;
        }

        private void SeedToppingTypeMultipliers()
        {
            toppingTypeMultipliers = new Dictionary<string, double>();

            toppingTypeMultipliers.Add("meat", 1.2);
            toppingTypeMultipliers.Add("veggies", 0.8);
            toppingTypeMultipliers.Add("cheese", 1.1);
            toppingTypeMultipliers.Add("sauce", 0.9);
        }
    }
}
