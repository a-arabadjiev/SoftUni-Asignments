namespace P02.BookShop
{
    using System.Linq;
    using System.Text;

    public class Book
    {
        private string author;
        private string title;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                string[] nameSplit = value.Split().ToArray();

                if (!(nameSplit.Length < 2))
                {
                    char secondNameLetter = nameSplit[1][0];

                    if (char.IsDigit(secondNameLetter))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }

                this.author = value;
            }
        }
        public string Title 
        {   
            get 
            { 
                return this.title; 
            } 
            set 
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value; 
            } 
        }
        public virtual decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Type: {this.GetType().Name}");
            stringBuilder.AppendLine($"Title: {this.Title}");
            stringBuilder.AppendLine($"Author: {this.Author}");
            stringBuilder.AppendLine($"Price: {this.Price:F2}");

            return stringBuilder.ToString().Trim();
        }
    }
}
