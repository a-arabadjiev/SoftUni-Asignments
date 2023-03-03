namespace P02.BookShop
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string author, string title, decimal price)
            :base(author, title,price)
        {

        }

        public override decimal Price { get => base.Price; set => base.Price = value * (decimal)1.30; }
    }
}
