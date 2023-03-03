namespace P03.ShoppingSpree.Models
{
    using System;
    using System.Text;

    public class Person
    {
        private string name;
        private double money;

        private List<Product> products;

        public Person(string name, double money)
        {
            this.products = new List<Product>();

            this.Name = name;
            this.Money = money;
        }

        public string Name 
        { 
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }
        public double Money 
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public bool BuyProduct(Product product)
        {
            if (this.Money - product.Cost < 0)
            {
                return false;
            }

            this.Money -= product.Cost;
            this.products.Add(product);

            return true;
        }

        public override string ToString()
        {
            StringBuilder personAsString = new StringBuilder();

            personAsString.Append($"{this.Name} - ");

            if (this.products.Count == 0)
            {
                personAsString.Append("Nothing bought");
                return personAsString.ToString().TrimEnd();
            }

            foreach (var product in this.products)
            {
                personAsString.Append($"{product.Name}, ");

                // Removes trailing comma
            }

            personAsString.Length--;
            personAsString.Length--;

            return personAsString.ToString().TrimEnd();
        }
    }
}
