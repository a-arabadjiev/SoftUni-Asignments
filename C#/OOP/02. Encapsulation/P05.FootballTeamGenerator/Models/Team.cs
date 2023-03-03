namespace P05.FootballTeamGenerator.Models
{
    using P05.FootballTeamGenerator.Models.Contracts;
    using P05.FootballTeamGenerator.Constraints;

    public class Team : ITeam
    {
        private readonly List<IPlayer> players;

        private string name;

        public Team(string name)
        {
            this.players = new List<IPlayer>();

            this.Name = name;
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
        public double Rating { get => this.CalculateRating(); }

        public void AddPlayer(IPlayer player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            IPlayer playerToRemove = this.players.FirstOrDefault(p => p.Name == playerName);

            if (playerToRemove == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PlayerIsNotInTheTeam, playerName, this.Name));
            }

            this.players.Remove(playerToRemove);
        }

        private double CalculateRating()
        {
            double sum = 0.0;

            foreach (var player in this.players)
            {
                sum += player.ReturnAverageStats();
            }

            return Math.Round(sum);
        }
    }
}
