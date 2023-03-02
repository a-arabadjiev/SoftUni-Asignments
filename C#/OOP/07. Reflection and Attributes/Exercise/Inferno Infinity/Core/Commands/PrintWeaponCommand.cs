namespace P07.InfernoInfinity.Core.Commands
{
    using P07.InfernoInfinity.Core.Commands.Contracts;
    using P07.InfernoInfinity.Models.Weapons.Base;
    using P07.InfernoInfinity.Repositories;

    using System;

    public class PrintWeaponCommand : ICommand
    {
        public void Execute(string[] paramaters, WeaponRepository weaponRepository)
        {
            string weaponName = paramaters[0];

            Weapon weapon = weaponRepository.ReturnFirstOrDefault(weaponName);

            Console.WriteLine(weapon);
        }
    }
}
