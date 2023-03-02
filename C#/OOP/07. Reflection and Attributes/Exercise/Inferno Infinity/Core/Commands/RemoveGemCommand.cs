namespace P07.InfernoInfinity.Core.Commands
{
    using P07.InfernoInfinity.Core.Commands.Contracts;
    using P07.InfernoInfinity.Models.Weapons.Base;
    using P07.InfernoInfinity.Repositories;

    public class RemoveGemCommand : ICommand
    {
        public void Execute(string[] paramaters, WeaponRepository weaponRepository)
        {
            string weaponName = paramaters[0];
            int socketIndex = int.Parse(paramaters[1]);

            Weapon weapon = weaponRepository.ReturnFirstOrDefault(weaponName);

            weapon.RemoveGem(socketIndex);
        }
    }
}
