namespace P05.FootballTeamGenerator.Repositories
{
    using P05.FootballTeamGenerator.Models.Contracts;
    using P05.FootballTeamGenerator.Constraints;

    public class TeamRepository
    {
        private readonly List<ITeam> teams;

        public TeamRepository()
        {
            this.teams = new List<ITeam>();
        }

        public void Add(ITeam team)
        {
            this.teams.Add(team);
        }

        public ITeam ReturnTeam(string name)
        {
            ITeam team = this.teams.FirstOrDefault(t => t.Name == name);

            if (team == null)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.TeamDoesNotExist, name));
            }

            return team;
        }
    }
}
