namespace P05.FootballTeamGenerator.Core
{
    using P05.FootballTeamGenerator.Models;
    using P05.FootballTeamGenerator.Models.Contracts;
    using P05.FootballTeamGenerator.Repositories;

    using System;

    public class CommandInterpreter
    {
        private TeamRepository teamRepository;

        public CommandInterpreter(TeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public void Interpret(List<string> paramaters)
        {
            string command = paramaters[0];
            paramaters.RemoveAt(0);

            if (command == "Team")
            {
                AddTeam(paramaters);
            }
            else if (command == "Add")
            {
                AddPlayer(paramaters);
            }
            else if (command == "Remove")
            {
                RemovePlayer(paramaters);
            }
            else if (command == "Rating")
            {
                PrintRating(paramaters);
            }
        }

        public void AddTeam(List<string> paramaters)
        {
            string teamName = paramaters[0];

            ITeam team = new Team(teamName);

            this.teamRepository.Add(team);
        }

        public void AddPlayer(List<string> paramaters)
        {
            string teamName = paramaters[0];

            ITeam team = this.teamRepository.ReturnTeam(teamName);

            string playerName = paramaters[1];
            int endurance = int.Parse(paramaters[2]);
            int sprint = int.Parse(paramaters[3]);
            int dribble = int.Parse(paramaters[4]);
            int passing = int.Parse(paramaters[5]);
            int shooting = int.Parse(paramaters[6]);

            IStats stats = new Stats(endurance, sprint, dribble, passing, shooting);

            IPlayer playerToAdd = new Player(playerName, stats);

            team.AddPlayer(playerToAdd);
        }

        public void RemovePlayer(List<string> paramaters)
        {
            string teamName = paramaters[0];
            string playerName = paramaters[1];

            ITeam team = this.teamRepository.ReturnTeam(teamName);

            team.RemovePlayer(playerName);
        }

        public void PrintRating(List<string> paramaters)
        {
            string teamName = paramaters[0];

            ITeam team = this.teamRepository.ReturnTeam(teamName);

            Console.WriteLine($"{teamName} - {team.Rating:F0}");
        }
    }
}
