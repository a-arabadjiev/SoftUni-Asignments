namespace P07.InfernoInfinity.Core.Commands
{
    using P07.InfernoInfinity.Core.Commands.Contracts;
    using P07.InfernoInfinity.Core.Factories;
   
    using P07.InfernoInfinity.Models.Weapons.Base;
    
    using P07.InfernoInfinity.Repositories;

    public class CreateWeaponCommand : ICommand
    {
        public void Execute(string[] paramaters, WeaponRepository weaponRepository)
        {
            WeaponFactory factory = new WeaponFactory();

            Weapon weapon = factory.Create(paramaters);

            weaponRepository.AddWeapon(weapon);
        }
    }
}
