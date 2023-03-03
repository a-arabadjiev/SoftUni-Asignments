namespace P05.FootballTeamGenerator.Models.Contracts
{
    public interface IPlayer
    {
        public string Name { get; }
        public IStats Stats { get; }

        public double ReturnAverageStats();
    }
}
