namespace P07.InfernoInfinity.Models.Weapons
{
    using P07.InfernoInfinity.Models.Weapons.Base;

    public class Sword : Weapon
    {
        public Sword(string name, WeaponRarity rarity)
            :base()
        {
            this.maxSockets = 3;

            this.MinDamage = 4;
            this.MaxDamage = 6;

            this.Name = name;
            this.Rarity = rarity;
        }

        public override int MinDamage { get; protected set; }

        public override int MaxDamage { get; protected set; }

        public override string Name { get; protected set; }

        public override WeaponRarity Rarity
        {
            get => this.rarity;
            protected set
            {
                this.rarity = value;

                this.MinDamage *= (int)value;
                this.MaxDamage *= (int)value;
            }
        }
    }
}
