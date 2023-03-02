namespace P07.InfernoInfinity.Repositories
{
    using P07.InfernoInfinity.Models.Weapons.Base;

    public class WeaponRepository
    {
        private List<Weapon> weapons;

        public WeaponRepository()
        {
            weapons = new List<Weapon>();
        }

        public void AddWeapon(Weapon weapon)
        {
            weapons.Add(weapon);
        }

        public Weapon ReturnFirstOrDefault(string name)
        {
            return weapons.FirstOrDefault(w => w.Name == name);
        }
    }
}
