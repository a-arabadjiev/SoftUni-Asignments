namespace P04.PizzaCalories
{
    using PizzaCalories.Models;

    using System.Linq;
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var pizzaNameInput = Console.ReadLine().Split().ToArray();
                string pizzaName = pizzaNameInput[1];

                var doughTypeInput = Console.ReadLine().Split().ToArray();
                string flourType = doughTypeInput[1];
                string bakingTechnique = doughTypeInput[2];
                int doughGrams = int.Parse(doughTypeInput[3]);

                var dough = new Dough(flourType, bakingTechnique, doughGrams);

                var pizza = new Pizza(pizzaName, dough);

                var toppingInput = Console.ReadLine().Split().ToArray();
                while (toppingInput[0].ToUpper() != "END")
                {
                    string toppingType = toppingInput[1];
                    int toppingGrams = int.Parse(toppingInput[2]);

                    var topping = new Topping(toppingType, toppingGrams);

                    pizza.AddTopping(topping);

                    toppingInput = Console.ReadLine().Split().ToArray();
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}