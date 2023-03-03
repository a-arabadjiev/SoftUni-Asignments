namespace P03.ShoppingSpree
{
    using P03.ShoppingSpree.Factories;
    using P03.ShoppingSpree.Models;

    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] personsInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                List<Person> persons = PersonFactory.CreatePersons(personsInput);

                string[] productsInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                List<Product> products = ProductFactory.CreateProducts(productsInput);

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] commandSplit = command.Split().ToArray();
                    string personName = commandSplit[0];
                    string productName = commandSplit[1];

                    Person person = persons.FirstOrDefault(p => p.Name == personName);
                    Product product = products.FirstOrDefault(p => p.Name == productName);

                    bool wasPurchaseSuccesful = person.BuyProduct(product);

                    if (!wasPurchaseSuccesful)
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }

                    command = Console.ReadLine();
                }

                persons.ForEach(p => Console.WriteLine(p));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}