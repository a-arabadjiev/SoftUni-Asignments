namespace P05.FootballTeamGenerator.Models.Contracts
{
    public interface ITeam
    {
        public string Name { get; }
        public double Rating { get; }

        public void AddPlayer(IPlayer player);
        public void RemovePlayer(string playerName);
    }
}
