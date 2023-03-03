namespace P04.PizzaCalories.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.toppings = new List<Topping>();

            this.Name = name;
            this.Dough = dough;
        }

        public Dough Dough { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        public int GetToppingsCount()
        {
            return this.toppings.Count;
        }

        public double GetCalories()
        {
            double doughCalories = this.Dough.GetCalories();
            double toppingsCalories = 0.0;

            foreach (var topping in this.toppings)
            {
                toppingsCalories += topping.GetCalories();
            }

            return doughCalories + toppingsCalories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.GetCalories():F2} Calories.";
        }
    }
}
