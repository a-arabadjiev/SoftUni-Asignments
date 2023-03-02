namespace P07.InfernoInfinity.Models.Weapons.Base
{
    using P07.InfernoInfinity.Models.Gems.Base;
    using P07.InfernoInfinity.Models.Sockets;

    using System.Collections.Generic;
    using System.Linq;

    public abstract class Weapon
    {
        protected List<Socket> sockets;
        protected WeaponRarity rarity;
        protected int maxSockets;

        public Weapon()
        {
            this.sockets = new List<Socket>();
        }

        public abstract int MinDamage { get; protected set; }

        public abstract int MaxDamage { get; protected set; }

        public abstract string Name { get; protected set; }

        public abstract WeaponRarity Rarity { get; protected set; }

        public void AddGem(Gem gem, int index)
        {
            if (!(index < 0 || index > this.maxSockets - 1))
            {
                Socket socket = new Socket(gem);

                if (this.sockets.ElementAtOrDefault(index) != null)
                {
                    this.RemoveGem(index);
                }

                this.sockets.Insert(index, socket);

                int[] damageAddition = this.sockets[index].Gem.TotalDamageAddition();
                this.MinDamage += damageAddition[0];
                this.MaxDamage += damageAddition[1];
            }
        }

        public void RemoveGem(int index)
        {
            if (!(index < 0 || index > this.maxSockets - 1) || this.sockets.ElementAtOrDefault(index) != null)
            {
                int[] damageAddition = this.sockets[index].Gem.TotalDamageAddition();
                this.MinDamage -= damageAddition[0];
                this.MaxDamage -= damageAddition[1];

                this.sockets.RemoveAt(index);
            }
        }

        public override string ToString()
        {
            int strengthAmount = 0;
            int agilityAmount = 0;
            int vitalityAmount = 0;

            this.sockets.ForEach(s => strengthAmount += s.Gem.Strength);
            this.sockets.ForEach(s => agilityAmount += s.Gem.Agility);
            this.sockets.ForEach(s => vitalityAmount += s.Gem.Vitality);

            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{strengthAmount} Strength, +{agilityAmount} Agility, +{vitalityAmount} Vitality";
        }
    }
}
