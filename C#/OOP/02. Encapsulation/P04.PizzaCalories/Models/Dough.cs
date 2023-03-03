namespace P04.PizzaCalories.Models
{
    using System.Collections.Generic;

    public class Dough
    {
        // Flour Type Multipliers
        private Dictionary<string, double> flourTypeMultipliers;
        private readonly double baseMultiplier = 2.0;

        // Baking Technique
        private Dictionary<string, double> bakingTechniquesMultipliers;

        // Standard Fields
        private int grams;
        private string flourType;
        private string bakingTechnique;

        public Dough(string flourType, string bakingTechnique, int grams)
        {
            this.SeedFlourTypeMultipliers();
            this.SeedBakingTechniques();

            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }

        private int Grams
        {
            get 
            { 
                return this.grams; 
            }
            set 
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.grams = value; 
            }
        }
        private string FlourType
        {
            get
            {
                return this.flourType;
            }
            set
            {
                if (!this.flourTypeMultipliers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }
        private string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            set
            {
                if (!this.bakingTechniquesMultipliers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public double GetCalories()
        {
            double calories = ((this.baseMultiplier * this.Grams) * this.flourTypeMultipliers[this.FlourType.ToLower()] * this.bakingTechniquesMultipliers[this.BakingTechnique.ToLower()]);

            return calories;
        }

        private void SeedBakingTechniques()
        {
            this.bakingTechniquesMultipliers = new Dictionary<string, double>();

            this.bakingTechniquesMultipliers.Add("crispy", 0.9);
            this.bakingTechniquesMultipliers.Add("chewy", 1.1);
            this.bakingTechniquesMultipliers.Add("homemade", 1.0);
        }

        private void SeedFlourTypeMultipliers()
        {
            this.flourTypeMultipliers = new Dictionary<string, double>();

            this.flourTypeMultipliers.Add("white", 1.5);
            this.flourTypeMultipliers.Add("wholegrain", 1.0);
        }
    }
}
