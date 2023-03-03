namespace P05.FootballTeamGenerator.Models
{
    using P05.FootballTeamGenerator.Models.Contracts;
    using P05.FootballTeamGenerator.Constraints;

    public class Stats : IStats
    {
        private const int minValue = 0;
        private const int maxValue = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance 
        {
            get => this.endurance; 
            private set
            {
                this.ValidateStat(value, nameof(Endurance));
                this.endurance = value;
            }
        }
        public int Sprint 
        {
            get => this.sprint;
            private set
            {
                this.ValidateStat(value, nameof(Sprint));
                this.sprint = value;
            }
        }
        public int Dribble 
        {
            get => this.dribble;
            private set
            {
                this.ValidateStat(value, nameof(Dribble));
                this.dribble = value;
            }
        }
        public int Passing 
        {
            get => this.passing;
            private set
            {
                this.ValidateStat(value, nameof(Passing));
                this.passing = value;
            }
        }
        public int Shooting 
        {
            get => this.shooting;
            private set
            {
                this.ValidateStat(value, nameof(Shooting));
                this.shooting = value;
            }
        }

        public int ReturnSum()
        {
            int sum = this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting;

            return sum;
        }

        private void ValidateStat(int value, string statName)
        {
            if (value < minValue || value > maxValue)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.InvalidStatRangeException, statName));
            }
        }
    }
}
