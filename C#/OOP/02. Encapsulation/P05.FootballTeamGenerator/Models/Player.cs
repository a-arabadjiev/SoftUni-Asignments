namespace P05.FootballTeamGenerator.Models
{
    using P05.FootballTeamGenerator.Models.Contracts;
    using P05.FootballTeamGenerator.Constraints;

    public class Player : IPlayer
    {
        private string name;

        public Player(string name, IStats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name 
        { 
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyName);
                }

                this.name = value;
            }
        }
        public IStats Stats { get; private set; }

        public double ReturnAverageStats()
        {
            return this.Stats.ReturnSum() / 5.0;
        }
    }
}
