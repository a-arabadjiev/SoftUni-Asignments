namespace P03.ShoppingSpree.Factories
{
    using P03.ShoppingSpree.Models;

    public static class ProductFactory
    {
        public static List<Product> CreateProducts(string[] productsInput)
        {
            List<Product> products = new List<Product>();

            for (int i = 0; i < productsInput.Length; i++)
            {
                string[] inputSplit = productsInput[i].Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = inputSplit[0];
                double cost = double.Parse(inputSplit[1]);

                Product product = new Product(name, cost);
                products.Add(product);
            }

            return products;
        }
    }
}
