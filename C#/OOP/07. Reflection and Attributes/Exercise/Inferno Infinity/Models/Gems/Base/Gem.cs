namespace P07.InfernoInfinity.Models.Gems.Base
{
    public abstract class Gem
    {
        protected GemClarity clarity;

        public abstract int Strength { get; protected set; }
        public abstract int Agility { get; protected set; }
        public abstract int Vitality { get; protected set; }
        public abstract GemClarity Clarity { get; protected set; }

        public int[] TotalDamageAddition()
        {
            int minDamageAdded = 0;
            minDamageAdded += this.Strength * 2;
            minDamageAdded += this.Agility;

            int maxDamageAdded = 0;
            maxDamageAdded += this.Strength * 3;
            maxDamageAdded += this.Agility * 4;

            return new int[] { minDamageAdded, maxDamageAdded};
        }
    }
}
