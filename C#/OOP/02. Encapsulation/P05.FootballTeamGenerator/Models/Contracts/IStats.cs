namespace P05.FootballTeamGenerator.Models.Contracts
{
    public interface IStats
    {
        public int Endurance { get; }
        public int Sprint { get; }
        public int Dribble { get; }
        public int Passing { get; }
        public int Shooting { get; }

        public int ReturnSum();
    }
}
