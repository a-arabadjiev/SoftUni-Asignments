namespace P05.FootballTeamGenerator
{
    using P05.FootballTeamGenerator.Repositories;
    using P05.FootballTeamGenerator.Core;

    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            TeamRepository teamRepository = new TeamRepository();

            string input = Console.ReadLine();

            while (input != "END")
            {
                List<string> inputSplit = input.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();

                CommandInterpreter commandInterpreter = new CommandInterpreter(teamRepository);

                try
                {
                    commandInterpreter.Interpret(inputSplit);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}