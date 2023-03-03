namespace P05.FootballTeamGenerator.Constraints
{
    public static class ExceptionMessages
    {
        public const string EmptyName = "A name should not be empty.";

        public const string PlayerIsNotInTheTeam = "Player {0} is not in {1} team.";

        public const string InvalidStatRangeException = "{0} should be between 0 and 100.";

        public const string TeamDoesNotExist = "Team {0} does not exist.";
    }
}
