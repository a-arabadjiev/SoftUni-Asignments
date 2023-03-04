namespace P04.OnlineRadioDatabase.Models
{
    using P04.OnlineRadioDatabase.Exceptions;

    public class Artist
    {
        private string name;

        public Artist(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }

                this.name = value;
            }
        }
    }
}
