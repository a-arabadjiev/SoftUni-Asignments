namespace P04.OnlineRadioDatabase.Models
{
    using P04.OnlineRadioDatabase.Exceptions;

    public class Song
    {
        private string name;
        private string length;
        private int minutes;
        private int seconds;

        public Song(string name, string length, int minutes, int seconds, Artist artist)
        {
            this.Name = name;
            this.Minutes = minutes;
            this.Seconds = seconds;
            this.Length = length;

            this.Artist = artist;
        }

        public Artist Artist { get; set; }

        public string Name 
        {
            get => this.name;
            private set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidSongNameException();
                }
                this.name = value;
            }
        }
        public int Minutes
        {
            get => this.minutes;
            private set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }

                this.minutes = value;
            }
        }
        public int Seconds
        {
            get => this.seconds;
            private set
            {
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }

                this.seconds = value;
            }
        }
        public string Length
        {
            get => this.length;
            private set => this.length = value;
        }
    }
}
