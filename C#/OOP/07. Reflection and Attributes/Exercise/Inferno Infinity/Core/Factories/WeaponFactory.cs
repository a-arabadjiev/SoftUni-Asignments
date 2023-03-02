namespace P07.InfernoInfinity.Core.Factories
{
    using P07.InfernoInfinity.Models.Weapons.Base;

    using System.Reflection;

    public class WeaponFactory
    {
        public Weapon Create(string[] paramaters)
        {
            string[] inputSplit = paramaters[0].Split().ToArray();

            WeaponRarity weaponRarity = (WeaponRarity)Enum.Parse(typeof(WeaponRarity), inputSplit[0]);
            string weaponType = inputSplit[1];
            string weaponName = paramaters[1];

            Type type = Type.GetType($"P07.InfernoInfinity.Models.Weapons.{weaponType}");
            ConstructorInfo constructor = type.GetConstructor(new[] { typeof(string), typeof(WeaponRarity) });

            Weapon weapon = (Weapon)constructor.Invoke(new object[] { weaponName, weaponRarity });

            return weapon;
        }
    }
}
