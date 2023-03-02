namespace P07.InfernoInfinity.Models.Gems
{
    using P07.InfernoInfinity.Models.Gems.Base;

    public class Emerald : Gem
    {
        public Emerald(GemClarity clarity)
        {
            this.Strength = 1;
            this.Agility = 4;
            this.Vitality = 9;

            this.Clarity = clarity;
        }

        public override int Strength { get; protected set; }

        public override int Agility { get; protected set; }

        public override int Vitality { get; protected set; }

        public override GemClarity Clarity
        {
            get => this.clarity;
            protected set
            {
                this.clarity = value;

                this.Strength += (int)value;
                this.Agility += (int)value;
                this.Vitality += (int)value;
            }
        }
    }
}